using System.Web.Optimization;

namespace EpamBlog
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.0.0.min.js",
                        "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/LayoutContent/css").Include(
                     "~/Content/BlogStyle.min.css",
                     "~/Content/Site.min.css",
                     "~/Content/Modal.min.css" ));

            bundles.Add(new ScriptBundle("~/LayoutScripts/js").Include(
                    "~/Scripts/initialization.min.js",
                    "~/Scripts/materialize.min.js",
                    "~/Scripts/HeadSlider.min.js"));
        }
    }
}
