using System.Web.Optimization;

namespace WebUI
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //      SCRIPTS
            //  Validation
            bundles.Add(new ScriptBundle("~/bundles/validation").Include(
                "~/Assets/js/vendor/jquery-1.12.2.min.js",
                "~/Assets/js/vendor/jquery.validate.min.js",
                "~/Assets/js/vendor/jquery.validate.unobtrusive.min.js",
                "~/Assets/js/vendor/attrchange.js",
                "~/Assets/js/validation.js"));

            //  Default
            bundles.Add(new ScriptBundle("~/bundles/default").Include(
                "~/Assets/js/vendor/jquery-1.12.2.min.js",
                "~/Assets/js/script.js"));

            //  Home Page
            bundles.Add(new ScriptBundle("~/bundles/index").Include(
                "~/Assets/js/vendor/jquery-1.12.2.min.js",
                "~/Assets/js/vendor/jquery.bxslider.min.js",
                "~/Assets/js/script.js",
                "~/Assets/js/index.js"));

            //  Catalog Page
            bundles.Add(new ScriptBundle("~/bundles/catalog").Include(
                "~/Assets/js/vendor/jquery-1.12.2.min.js",
                "~/Assets/js/vendor/jquery.cookie.js",
                "~/Assets/js/script.js",
                "~/Assets/js/catalog.js"));

            //  Brands Page
            bundles.Add(new ScriptBundle("~/bundles/brands").Include(
                "~/Assets/js/vendor/jquery-1.12.2.min.js",
                "~/Assets/js/script.js",
                "~/Assets/js/brands.js"));

            //  Product Page
            bundles.Add(new ScriptBundle("~/bundles/product").Include(
                "~/Assets/js/vendor/jquery-1.12.2.min.js",
                "~/Assets/js/vendor/smoothproducts.min.js",
                //"//s7.addthis.com/js/300/addthis_widget.js#pubid=ra-570a42d3bf6f5f54",
                "~/Assets/js/script.js",
                "~/Assets/js/product.js"));

            //  Article Page
            bundles.Add(new ScriptBundle("~/bundles/article").Include(
                "~/Assets/js/vendor/jquery-1.12.2.min.js",
                //"//s7.addthis.com/js/300/addthis_widget.js#pubid=ra-570a42d3bf6f5f54",
                //"//s7.addthis.com/js/300/addthis_widget.js#pubid=ra-570a42d3bf6f5f54",
                "~/Assets/js/script.js"));

            //  Contact Us Page
            bundles.Add(new ScriptBundle("~/bundles/contact-us").Include(
                "~/Assets/js/vendor/jquery-1.12.2.min.js",
                "~/Assets/js/script.js",
                "~/Assets/js/vendor/jquery.validate.min.js",
                "~/Assets/js/vendor/jquery.validate.unobtrusive.min.js",
                "~/Assets/js/vendor/attrchange.js",
                "~/Assets/js/validation.js"));

            //  Login Pages
            bundles.Add(new ScriptBundle("~/bundles/login").Include(
                "~/Assets/js/vendor/jquery-1.12.2.min.js",
                "~/Assets/js/script.js",
                "~/Assets/js/vendor/jquery.validate.min.js",
                "~/Assets/js/vendor/jquery.validate.unobtrusive.min.js",
                "~/Assets/js/vendor/attrchange.js",
                "~/Assets/js/validation.js"));

            BundleTable.EnableOptimizations = true;
        }
    }
}