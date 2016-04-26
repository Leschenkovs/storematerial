using System.Web.Optimization;

namespace Store.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Store.Web/base").Include(
               "~/Scripts/bootstrap.min.js",
               "~/Scripts/ng-table.js",
               "~/Scripts/underscore.min.js",
                //"~/Scripts/modernizr.custom.js",
               "~/Scripts/lodash.min.js",
               "~/Scripts/multiselect.js"
              ));

            bundles.Add(new ScriptBundle("~/Store.Web/jquery").Include(
                "~/Scripts/jquery-1.9.1.min.js"
              ));

            bundles.Add(new ScriptBundle("~/Store.Web/angular").Include(
                "~/Scripts/angular/angular.min.js",
                "~/Scripts/angular/angular-animate.min.js",
                "~/Scripts/angular/angular-loader.min.js",
                "~/Scripts/angular/angular-sanitize.min.js",
                "~/Scripts/angular/angular-locale_ru-ru.js",
                "~/Scripts/angular/angular-cookies.min.js",
                "~/Scripts/angular/angular-messages.min.js",
                "~/Scripts/angular/angular-touch.min.js",
                "~/Scripts/angular/angular-resource.min.js",
                "~/Scripts/angular/ui-bootstrap.min.js",
                "~/Scripts/angular/ui-bootstrap-tpls.min.js",
                "~/Scripts/angular/angular-ui-router.min.js",
                "~/Scripts/angular/angular-ui-ieshiv.min.js",
                "~/Scripts/angular/angular-ui.min.js",
                "~/Scripts/angular/date.js"
                ));

            bundles.Add(new StyleBundle("~/Store.Web/css").Include(
                "~/Content/styles/*.css",
                "~/Content/*.css"
                ));

            bundles.Add(new ScriptBundle("~/Store.Web/app").Include(
                "~/Angular/app.js",
                "~/Angular/app.config.js",
                "~/Angular/helpers/*.js",
                "~/Angular/services/*.js",
                "~/Angular/directives/*.js",
                "~/Angular/controllers/*.js",
                "~/Angular/filters/*.js"
                ));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;
        }
    }
}