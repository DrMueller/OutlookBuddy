using System.Threading.Tasks;
using Microsoft.Office.Interop.Outlook;

namespace OutlookBuddy.Areas.AzureDevOps.CreateWorkItem.Services
{
    public interface IWorkItemFactory
    {
        Task CreateAsync(MailItem mailItem);
    }
}