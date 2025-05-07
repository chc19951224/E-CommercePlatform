using System.Web;
using System.Web.Optimization;

namespace E_CommercePlatform.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //***** JS 脚本文件类型的捆绑 *****//
            bundles.Add(new ScriptBundle("~/bundles/official/jquery").Include(
                        "~/Content/JqueryScripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/official/jqueryval").Include(
                        "~/Content/JqueryScripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/official/modernizr").Include(
                        "~/Content/JqueryScripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/official/bootstrap").Include(
                      "~/Content/OfficialTheme/assets/js/bootstrap.js"));

            // 【HexaShop】【_MainLayout】捆绑自定义Bootstrap的所需脚本
            bundles.Add(new ScriptBundle("~/bundles/_MainLayout/Hexa/js").Include(
                        //jQuery
                        "~/Content/HexaShop/assets/js/jquery-2.1.0.min.js",

                        //Bootstrap
                        "~/Content/HexaShop/assets/js/popper.js",
                        "~/Content/HexaShop/assets/js/bootstrap.min.js",

                        //Plugins
                        "~/Content/HexaShop/assets/js/owl-carousel.js",
                        "~/Content/HexaShop/assets/js/accordions.js",
                        "~/Content/HexaShop/assets/js/datepicker.js",
                        "~/Content/HexaShop/assets/js/scrollreveal.min.js",
                        "~/Content/HexaShop/assets/js/waypoints.min.js",
                        "~/Content/HexaShop/assets/js/jquery.counterup.min.js",
                        "~/Content/HexaShop/assets/js/imgfix.min.js",
                        "~/Content/HexaShop/assets/js/slick.js",
                        "~/Content/HexaShop/assets/js/lightbox.js",
                        "~/Content/HexaShop/assets/js/isotope.js",

                        //Global Init
                        "~/Content/HexaShop/assets/js/custom.js"
                        ));

            // 【ShionHouse】【_xx】捆绑自定义Bootstrap的所需脚本
            bundles.Add(new ScriptBundle("~/bundles/xx/Shion/js").Include(
                      //Jquery, Popper, Bootstrap
                      "~/Content/ShionHouse/assets/vendor/js/vendor/modernizr-3.5.0.min.js",
                      "~/Content/ShionHouse/assets/vendor/jquery-1.12.4.min.js",
                      "~/Content/ShionHouse/assets/js/popper.min.js",
                      "~/Content/ShionHouse/assets/js/bootstrap.min.js",

                      //Slick-slider , Owl-Carousel ,slick-nav
                      "~/Content/ShionHouse/assets/js/owl.carousel.min.js",
                      "~/Content/ShionHouse/assets/js/slick.min.js",
                      "~/Content/ShionHouse/assets/js/jquery.slicknav.min.js",

                      //One Page, Animated-HeadLin, Date Picker
                      "~/Content/ShionHouse/assets/js/wow.min.js",
                      "~/Content/ShionHouse/assets/js/animated.headline.js",
                      "~/Content/ShionHouse/assets/js/jquery.magnific-popup.js",
                      "~/Content/ShionHouse/assets/js/gijgo.min.js",

                      //Nice-select, sticky,Progress
                      "~/Content/ShionHouse/assets/js/jquery.nice-select.min.js",
                      "~/Content/ShionHouse/assets/js/jquery.sticky.js",
                      "~/Content/ShionHouse/assets/js/jquery.barfiller.js",

                      //counter , waypoint,Hover Direction
                      "~/Content/ShionHouse/assets/js/jquery.counterup.min.js",
                      "~/Content/ShionHouse/assets/js/waypoints.min.js",
                      "~/Content/ShionHouse/assets/js/jquery.countdown.min.js",
                      "~/Content/ShionHouse/assets/js/hover-direction-snake.min.js",

                      //contact js
                      "~/Content/ShionHouse/assets/js/contact.js",
                      "~/Content/ShionHouse/assets/js/jquery.form.js",
                      "~/Content/ShionHouse/assets/js/jquery.validate.min.js",
                      "~/Content/ShionHouse/assets/js/mail-script.js",
                      "~/Content/ShionHouse/assets/js/jquery.ajaxchimp.min.js",

                      //【网页预加载特效Jquery】plugins，main
                      "~/Content/ShionHouse/assets/js/plugins.js",
                      "~/Content/ShionHouse/assets/js/main.js"));


            //***** JS 脚本文件类型的捆绑 *****//
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/OfficialTheme/assets/css/bootstrap.css",
                      "~/Content/OfficialTheme/assets/css/site.css"));

            // 【HexaShop】【_MainLayout】捆绑自定义Bootstrap的所需样式
            bundles.Add(new StyleBundle("~/bundles/_MainLayout/Hexa/css").Include(
                        "~/Content/HexaShop/assets/css/bootstrap.min.css",
                        "~/Content/HexaShop/assets/css/font-awesome.css",
                        "~/Content/HexaShop/assets/css/templatemo-hexashop.css",
                        "~/Content/HexaShop/assets/css/owl-carousel.css",
                        "~/Content/HexaShop/assets/css/lightbox.css"));

            // 【ShionHouse】【_xx】捆绑自定义Bootstrap所需样式
            bundles.Add(new StyleBundle("~/bundles/xx/Shion/css").Include(
                      "~/Content/ShionHouse/assets/css/bootstrap.min.css",
                      "~/Content/ShionHouse/assets/css/owl.carousel.min.css",
                      "~/Content/ShionHouse/assets/css/slicknav.css",
                      "~/Content/ShionHouse/assets/css/flaticon.css",
                      "~/Content/ShionHouse/assets/css/progressbar_barfiller.css",
                      "~/Content/ShionHouse/assets/css/gijgo.css",
                      "~/Content/ShionHouse/assets/css/animate.min.css",
                      "~/Content/ShionHouse/assets/css/animated-headline.css",
                      "~/Content/ShionHouse/assets/css/magnific-popup.css",
                      "~/Content/ShionHouse/assets/css/fontawesome-all.min.css",
                      "~/Content/ShionHouse/assets/css/themify-icons.css",
                      "~/Content/ShionHouse/assets/css/slick.css",
                      "~/Content/ShionHouse/assets/css/nice-select.css",
                      "~/Content/ShionHouse/assets/css/style.css"));
        }
    }
}