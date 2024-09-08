using System.Threading.Tasks;
using OutlookBuddy.Areas.AzureDevOps.Shared.AzureDevOpsProxy.Models;

namespace OutlookBuddy.Areas.AzureDevOps.Shared.AzureDevOpsProxy.Services
{
    public interface IWorkItemTrackingClientProxy
    {
        Task CreateAsync(WorkItem workItem);
    }
}