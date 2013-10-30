using System.Web.Optimization;

namespace YankeesCodeChallenge
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/Styles/Bundles/default-style")
                            .Include("~/Content/Styles/jQueryUI/smoothness/jquery-ui-1.10.3.custom.css",
                                     "~/Content/Styles/site.css",
                                     "~/Content/Styles/960_12_col.css",
                                     "~/Content/Styles/Pluggins/datatables.css"));

            bundles.Add(new ScriptBundle("~/Content/Scripts/Bundles/default-scripts")
                    .Include("~/Content/Scripts/jQuery/jquery-2.0.3.min.js",
                             //"~/Content/Scripts/jQueryUI/jquery-ui-1.10.3.custom.min.js",
                             "~/Content/Scripts/AngularJs/angular.min.js",
                             "~/Content/Scripts/YankeesCodeChallenge.js",
                             "~/Content/Scripts/AngularJs/app.js",
                             "~/Content/Scripts/Shared/shared-directives.js"));
        }
    }
}