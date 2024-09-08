namespace OutlookBuddy.Areas.AzureDevOps.Shared.AzureDevOpsProxy.Models
{
    public class WorkItem
    {
        public WorkItem(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public string Title { get; }
        public string Description { get; }
    }
}