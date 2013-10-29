using System.Web.Optimization;

[assembly: WebActivator.PostApplicationStartMethod(typeof(YankeesCodeChallenge.BundleConfigurationActivator), "Activate")]
namespace YankeesCodeChallenge
{
    public static class BundleConfigurationActivator
    {
        public static void Activate()
        {
            BundleTable.Bundles.RegisterConfigurationBundles();
        }
    }
}