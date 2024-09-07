using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lamar;
using OutlookBuddy.Areas.AzureDevOps.Ribbons;

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
