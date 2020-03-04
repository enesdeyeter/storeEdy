using System.Web;
using System.Web.Optimization;

namespace storeEdy
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Content/vendor/jquery/dist/jquery.min.js",
                "~/Content/vendor/bootstrap/dist/js/bootstrap.bundle.min.js",

                "~/Content/vendor/chart.js/dist/Chart.min.js",
                "~/Content/vendor/chart.js/dist/Chart.extension.js",


                
                "~/Content/js/argon.js?v=1.0.0"));




                 bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/vendor/@fortawesome/fontawesome-free/css/all.min.css",
                "~/Content/vendor/nucleo/css/nucleo.css",
                "~/Content/endor/bootstrap/css/bootstrap.min.css",
                "~/Content/css/argon.css"));

        }
    }
}
