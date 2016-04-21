using System;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using Store.Bll;
using Store.Model;

namespace Store.Web.Modules
{
    public class BasicAuthHttpModule : IHttpModule
    {
        private const string Realm = "AngularWebAPI";

        public void Init(HttpApplication context)
        {
            // Register event handlers
            context.AuthenticateRequest += OnApplicationAuthenticateRequest;
            context.EndRequest += OnApplicationEndRequest;
        }

        private static void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }

        private static bool AuthenticateUser(string credentials)
        {
            Encoding encoding = Encoding.GetEncoding("iso-8859-1");
            credentials = encoding.GetString(Convert.FromBase64String(credentials));

            string[] credentialsArray = credentials.Split(':');
            string username = credentialsArray[0];
            string password = credentialsArray[1];

            User user = GetUser(username, password);
            if (user == null)
            {
                return false;
            }

            GenericIdentity identity = new GenericIdentity(username);
            SetPrincipal(new GenericPrincipal(identity, new string[] {user.RoleObj.Code} ));

            return true;
        }

        private static void OnApplicationAuthenticateRequest(object sender, EventArgs e)
        {
            var request = HttpContext.Current.Request;
            var authHeader = request.Headers["Authorization"];
            if (authHeader != null)
            {
                AuthenticationHeaderValue authHeaderVal = AuthenticationHeaderValue.Parse(authHeader);

                // RFC 2617 sec 1.2, "scheme" name is case-insensitive
                if (authHeaderVal.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) && authHeaderVal.Parameter != null)
                {
                    AuthenticateUser(authHeaderVal.Parameter);
                }
            }
        }

        // If the request was unauthorized, add the WWW-Authenticate header to the response.
        private static void OnApplicationEndRequest(object sender, EventArgs e)
        {
            HttpResponse response = HttpContext.Current.Response;
            if (response.StatusCode == 401)
            {
                response.Headers.Add("WWW-Authenticate", string.Format("Basic realm=\"{0}\"", Realm));
            }
        }

        private static User GetUser(string username, string password)
        {
            IFactoryBll factoryBll = new FactoryBll();
            User user = factoryBll.UserBll.GetByLoginAndPassword(username, password);
            return user;
        }

        public void Dispose()
        {
        }
    }
}