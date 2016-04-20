using System.Web.Optimization;

namespace Store.Web.App_Start
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
		  bundles.Add(new ScriptBundle("~/Store.Web/base").Include(
			 "~/Scripts/jquery-1.9.1*",
			 "~/Scripts/bootstrap.js",
			 "~/Scripts/ng-table.js",
			 "~/Scripts/underscore.js",
			 "~/Scripts/lodash.js"
			));

			bundles.Add(new ScriptBundle("~/Store.Web/angular").Include(
				"~/Scripts/angular/modernizr.custom.js",
				"~/Scripts/angular/angular.js",
				"~/Scripts/angular/angular-messages.min.js",
				"~/Scripts/angular/angular-sanitize.js",
				"~/Scripts/angular/ui-bootstrap.js",
				"~/Scripts/angular/ui-bootstrap-tpls.js",
				"~/Scripts/angular/angular-ui-router.js",
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