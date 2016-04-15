using System.Web.Optimization;

namespace Store.Web.App_Start
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/Store.Web/angular").Include(
											"~/packages/angularjs.1.5.3/content/Scripts/angular.js",
											"~/packages/angularjs.1.5.3/content/Scripts/angular-sanitize.js",
											"~/packages/Angular.UI.Bootstrap.1.3.1/content/Scripts/angular-ui/ui-bootstrap.js",
											"~/packages/Angular.UI.Bootstrap.1.3.1/content/Scripts/angular-ui/ui-bootstrap-tpls.js",
											"~/packages/Angular.UI.UI-Router.0.2.18/content/scripts/angular-ui-router.js",
											"~/packages/angular-ui-date.1.0.0/content/Scripts/date.js"
									));

			/*bundles.Add(new ScriptBundle("~/Store.Web/app").Include(
											"~/Angular/app.js",
											"~/Angular/app.config.js",
											"~/Angular/helpers/*.js",
											"~/Angular/services/*.js",
											"~/Angular/directives/*.js",
											"~/Angular/controllers/*.js"
									));
			*/

			// Set EnableOptimizations to false for debugging. For more information,
			// visit http://go.microsoft.com/fwlink/?LinkId=301862
			BundleTable.EnableOptimizations = false;
		}
	}
}