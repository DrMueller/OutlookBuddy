using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lamar;
using OutlookBuddy.Infrastructure.DependencyInjection;

namespace OutlookBuddy.Infrastructure.Context
{
    internal static class OutlookAppContext
    {
        internal static async Task ExecuteAsync(Func<IContainer, Task> callback)
        {
            try
            {
                var container = ContainerFactory.Create();
                await callback(container);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (Debugger.IsAttached) Debugger.Break();
            }
        }
    }
}