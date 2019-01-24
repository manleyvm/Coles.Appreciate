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
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                        "~/Scripts/knockout-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/autosize").Include(
                        "~/Scripts/autosize/autosize.js"));

            bundles.Add(new ScriptBundle("~/bundles/alertify").Include(
                        "~/Scripts/alertify.js"));

            bundles.Add(new StyleBundle("~/Content/general").Include(
                      "~/Content/css/site.css",
                      "~/Content/css/app.css"));

            bundles.Add(new StyleBundle("~/Content/alertify").Include(
                      "~/Content/alertifyjs/alertify.css",
                      "~/Content/alertifyjs/themes/default.css"));
            
            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                      "~/Content/bootstrap.css"));


        }
    }
}
