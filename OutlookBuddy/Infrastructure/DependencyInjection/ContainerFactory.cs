using Lamar;
using OutlookBuddy.Areas.AzureDevOps.Shared.Ribbons;

namespace OutlookBuddy.Infrastructure.DependencyInjection
{
    internal static class ContainerFactory
    {
        internal static IContainer Create()
        {
            return new Container(cfg =>
            {
                cfg.Scan(scanner =>
                {
                    scanner.AssemblyContainingType<AzureDevOpsRibbon>();
                    scanner.WithDefaultConventions();
                });
            });
        }
    }
}