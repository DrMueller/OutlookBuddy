using System.Threading.Tasks;
using Microsoft.Office.Interop.Outlook;
using OutlookBuddy.Areas.AzureDevOps.Shared.AzureDevOpsProxy.Models;
using OutlookBuddy.Areas.AzureDevOps.Shared.AzureDevOpsProxy.Services;

namespace OutlookBuddy.Areas.AzureDevOps.CreateWorkItem.Services.Implementation
{
    public class WorkItemFactory : IWorkItemFactory
    {
        private readonly IWorkItemTrackingClientProxy _clientProxy;

        public WorkItemFactory(IWorkItemTrackingClientProxy clientProxy)
        {
            _clientProxy = clientProxy;
        }

        public async Task CreateAsync(MailItem mailItem)
        {
            var workItem = new WorkItem(
                mailItem.Subject,
                mailItem.HTMLBody);

            await _clientProxy.CreateAsync(workItem);
        }
    }
}