using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Outlook;

namespace OutlookBuddy.Areas.AzureDevOps.CreateWorkItem.Services
{
    public interface IWorkItemFactory
    {
        Task CreateAsync(MailItem mailItem);
    }
}
