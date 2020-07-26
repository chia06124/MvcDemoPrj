using System.Web;
using System.Web.Optimization;

namespace MvcDemoPrj
{
    public class BundleConfig
    {
        // 如需「搭配」的詳細資訊，請瀏覽 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/loginjs").Include(
                        "~/Content/vendor/jquery/jquery.js"
                        , "~/Content/vendor/bootstrap/js/bootstrap.bundle.js"
                        , "~/Content/vendor/jquery-easing/jquery.easing.js"
                        , "~/Content/js/sb-admin-2.js"));

             bundles.Add(new ScriptBundle("~/bundles/indexjs").Include(
                        "~/Content/vendor/jquery/jquery.js"
                        , "~/Content/vendor/bootstrap/js/bootstrap.bundle.js"
                        , "~/Content/vendor/jquery-easing/jquery.easing.js"
                        , "~/Content/js/sb-admin-2.js"
                        , "~/Content/vendor/datatables/jquery.dataTables.js"
                        , "~/Content/vendor/datatables/dataTables.bootstrap4.js"
                        , "~/Content/js/demo/datatables-demo.js"
                        , "~/Scripts/jquery.validate.min.js"
                        , "~/Scripts/jquery.validate.unobtrusive.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/datepickerjs").Include(
                        "~/Scripts/moment.js"
                        , "~/Scripts/bootstrap-datetimepicker.js"
                        ,"~/Scripts/bootstrap-datepicker.js"));


            bundles.Add(new ScriptBundle("~/bundles/selectjs").Include(
                       "~/Scripts/bootstrap-select.js"));

            // 使用開發版本的 Modernizr 進行開發並學習。然後，當您
            // 準備好實際執行時，請使用 http://modernizr.com 上的建置工具，只選擇您需要的測試。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/content/logincss").Include(
                      "~/Content/vendor/fontawesome-free/css/all.css",
                      "~/Content/css/sb-admin-2.css"));

            bundles.Add(new StyleBundle("~/content/indexcss").Include(
                      "~/Content/vendor/fontawesome-free/css/all.css",
                      "~/Content/css/sb-admin-2.css",
                      "~/Content/vendor/datatables/dataTables.bootstrap4.css"));
            bundles.Add(new StyleBundle("~/content/datepickercss").Include(
                      "~/Content/bootstrap-datepicker.css"));

            bundles.Add(new StyleBundle("~/content/selectcss").Include(
                      "~/Content/bootstrap-select.css"));

        }
    }
}
