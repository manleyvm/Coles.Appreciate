using System.Web;
using System.Web.Optimization;

namespace Coles.Appreciate.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/libs/jquery/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Content/libs/jquery/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Content/libs/modernizr/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/libs/bootstrap/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                        "~/Content/libs/knockout/knockout-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/autosize").Include(
                        "~/Content/libs/autosize/autosize.js"));

            bundles.Add(new ScriptBundle("~/bundles/alertify").Include(
                        "~/Content/libs/alertify/alertify.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/site.css",
                      "~/Content/css/app.css",
                      "~/Content/css/alertifyjs/alertify.css",
                      "~/Content/css/alertifyjs/themes/default.css"/*,
                      "~/Content/css/alertify/themes/bootstrap.css"*/));




        }
    }
}
