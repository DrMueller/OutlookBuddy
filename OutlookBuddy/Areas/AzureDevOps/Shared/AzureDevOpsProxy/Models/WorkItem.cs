using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookBuddy.Areas.AzureDevOps.Shared.AzureDevOpsProxy.Models
{
   public class WorkItem
    {
        public string Title { get; }

        public WorkItem(string title)
        {
            Title = title;
        }
    }
}
