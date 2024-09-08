using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Outlook;
using OutlookBuddy.Areas.AzureDevOps.CreateWorkItem.Services;
using OutlookBuddy.Infrastructure.Context;

namespace OutlookBuddy.Areas.AzureDevOps.Shared.Ribbons
{
    [ComVisible(true)]
    public class AzureDevOpsRibbon : IRibbonExtensibility
    {
        private IRibbonUI ribbon;

        #region IRibbonExtensibility Members

        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("OutlookBuddy.Areas.AzureDevOps.Shared.Ribbons.AzureDevOpsRibbon.xml");
        }

        #endregion

        #region Ribbon Callbacks

        //Create callback methods here. For more information about adding callback methods, visit https://go.microsoft.com/fwlink/?LinkID=271226

        public void Ribbon_Load(IRibbonUI ribbonUI)
        {
            ribbon = ribbonUI;
        }

        #endregion

        #region Helpers

        private static string GetResourceText(string resourceName)
        {
            var asm = Assembly.GetExecutingAssembly();
            var resourceNames = asm.GetManifestResourceNames();
            for (var i = 0; i < resourceNames.Length; ++i)
                if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
                    using (var resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
                    {
                        if (resourceReader != null) return resourceReader.ReadToEnd();
                    }

            return null;
        }

        #endregion

        public Bitmap CreateWorkItemImage(IRibbonControl control)
        {
            // Load the embedded resource (custom image)
            var imageName = "OutlookBuddy.Infrastructure.Assets.M.png";
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(imageName))
            {
                return new Bitmap(stream);
            }
        }

        public async void HandleCreateWorkItemClicked(IRibbonControl control)
        {
            await OutlookAppContext.ExecuteAsync(async container =>
            {
                var explorer = Globals.ThisAddIn.Application.ActiveExplorer();
                var selection = explorer.Selection;

                if (selection.Count > 0)
                {
                    if (selection[1] is MailItem mailItem)
                    {
                        var wiFactory = container.GetInstance<IWorkItemFactory>();
                        await wiFactory.CreateAsync(mailItem);
                    }
                    else
                    {
                        MessageBox.Show("No mail item is selected.");
                    }
                }
            });
        }
    }
}