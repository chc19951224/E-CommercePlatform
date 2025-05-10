using System.Web;
using System.Web.Optimization;

namespace E_CommercePlatform.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //***** JS 脚本文件类型的捆绑 *****//
            bundles.Add(new ScriptBundle("~/bundles/Support/jquery").Include(
                        "~/Content/JqueryScriptsSupport/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/Support/jqueryval").Include(
                        "~/Content/JqueryScriptsSupport/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/Support/modernizr").Include(
                        "~/Content/JqueryScriptsSupport/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/Support/bootstrap").Include(
                      "~/Content/DefaultTheme/assets/js/bootstrap.js"));

            //【Client】捆绑自定义Bootstrap的所需脚本
            bundles.Add(new ScriptBundle("~/bundles/ClientTheme/js").Include(
                        //jQuery
                        "~/Content/ClientTheme/assets/js/jquery-2.1.0.min.js",

                        //Bootstrap
                        "~/Content/ClientTheme/assets/js/popper.js",
                        "~/Content/ClientTheme/assets/js/bootstrap.min.js",

                        //Plugins
                        "~/Content/ClientTheme/assets/js/owl-carousel.js",
                        "~/Content/ClientTheme/assets/js/accordions.js",
                        "~/Content/ClientTheme/assets/js/datepicker.js",
                        "~/Content/ClientTheme/assets/js/scrollreveal.min.js",
                        "~/Content/ClientTheme/assets/js/waypoints.min.js",
                        "~/Content/ClientTheme/assets/js/jquery.counterup.min.js",
                        "~/Content/ClientTheme/assets/js/imgfix.min.js",
                        "~/Content/ClientTheme/assets/js/slick.js",
                        "~/Content/ClientTheme/assets/js/lightbox.js",
                        "~/Content/ClientTheme/assets/js/isotope.js",

                        //Global Init
                        "~/Content/ClientTheme/assets/js/custom.js"
                        ));

            //【Dashboard】捆绑自定义Bootstrap的所需脚本
            bundles.Add(new ScriptBundle("~/bundles/DashboardTheme/js").Include(
                      //metisMenu
                      "~/Content/DashboardTheme/assets/js/metisMenu.min.js",

                      //Required vendors
                      "~/Content/DashboardTheme/assets/js/global.min.js",
                      "~/Content/DashboardTheme/assets/js/quixnav-init.js",
                      "~/Content/DashboardTheme/assets/js/custom.min.js",

                      //Vectormap
                      "~/Content/DashboardTheme/assets/js/raphael.min.js",
                      "~/Content/DashboardTheme/assets/js/morris.min.js",
                      "~/Content/DashboardTheme/assets/js/circle-progress.min.js",
                      "~/Content/DashboardTheme/assets/js/Chart.bundle.min.js",
                      "~/Content/DashboardTheme/assets/js/gauge.min.js",

                      //flot-chart js
                      "~/Content/DashboardTheme/assets/js/jquery.flot.js",
                      "~/Content/DashboardTheme/assets/js/jquery.flot.resize.js",

                      //Owl Carousel
                      "~/Content/DashboardTheme/assets/js/owl.carousel.min.js",

                      //Counter Up
                      "~/Content/DashboardTheme/assets/js/jquery.vmap.min.js",
                      "~/Content/DashboardTheme/assets/js/jquery.vmap.usa.js",
                      "~/Content/DashboardTheme/assets/js/jquery.counterup.min.js",
                      "~/Content/DashboardTheme/assets/js/dashboard-1.js"));


            //***** CSS 样式文件类型的捆绑 *****//
            bundles.Add(new StyleBundle("~/Content/DefaultTheme/css").Include(
                      "~/Content/DefaultTheme/assets/css/bootstrap.css",
                      "~/Content/DefaultTheme/assets/css/site.css"));

            //【Client】捆绑自定义Bootstrap的所需样式
            bundles.Add(new StyleBundle("~/bundles/ClientTheme/css").Include(
                        "~/Content/ClientTheme/assets/css/bootstrap.min.css",
                        "~/Content/ClientTheme/assets/css/font-awesome.css",
                        "~/Content/ClientTheme/assets/css/templatemo-hexashop.css",
                        "~/Content/ClientTheme/assets/css/owl-carousel.css",
                        "~/Content/ClientTheme/assets/css/lightbox.css"));

            //【Dashboard】捆绑自定义Bootstrap所需样式
            bundles.Add(new StyleBundle("~/bundles/DashboardTheme/css").Include(
                      //metisMenu
                      "~/Content/DashboardTheme/assets/css/metisMenu.min.css",

                      "~/Content/DashboardTheme/assets/css/owl.carousel.min.css",
                      "~/Content/DashboardTheme/assets/css/owl.theme.default.min.css",
                      "~/Content/DashboardTheme/assets/css/jqvmap.min.css",
                      "~/Content/DashboardTheme/assets/css/style.css"));
        }
    }
}