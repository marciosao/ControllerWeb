using System.Web;
using System.Web.Optimization;

namespace ControllerWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js",
            //            "~/Scripts/jquery.unobtrusive-ajax.js",
            //            "~/Scripts/jquery.maskedinput-1.3.1.js",
            //            "~/Scripts/google-code-prettify/prettify.js",
            //            "~/Scripts/jquery.ui.widget.js",
            //            "~/Scripts/bootstrap-datepicker.js",
            //            "~/Scripts/bootbox.js",
            //            "~/Scripts/jquery.maskMoney.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                                //"~/Scripts/jquery-{version}.js",
                                //"~/Scripts/jjquery-2.2.4.min.js",
                                //"~/Scripts/jquery-1.12.4.min.js",
                                "~/Scripts/jquery.unobtrusive-ajax.min.js",
                                "~/Scripts/jquery.maskedinput-1.3.1.min.js",
                                "~/Scripts/jquery-ui-1.11.4.min.js",
                                "~/Scripts/jquery.ui.widget.js",
                                "~/Scripts/bootstrap-datepicker.js",
                                "~/Scripts/bootstrap.min.js",
                                "~/Scripts/bootbox.js",
                                "~/Scripts/select2.full.js",
                                "~/Scripts/jquery.maskMoney.min.js",
                                "~/Scripts/Views/Util.js"
                                
            ));


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/methods_pt.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap-datepicker.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/jquery-ui.min.css",
                    "~/Content/jquery-ui.structure.min.css",
                    "~/Content/jquery-ui.theme.min.css",
                    "~/Content/bootstrap.min.css",
                    "~/Content/bootstrap-theme.min.css",
                    "~/Content/font-awesome.css",
                    "~/Content/PagedList.css",
                    "~/Content/bootstrap-datepicker.css",
                    "~/Content/bootstrap-datepicker3.css",
                    "~/Content/select2.min.css",
                    "~/Content/Site.css"));
        }
    }
}
