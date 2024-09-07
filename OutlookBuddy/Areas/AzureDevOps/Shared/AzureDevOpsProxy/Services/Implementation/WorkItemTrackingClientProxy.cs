using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using Microsoft.VisualStudio.Services.WebApi.Patch;
using Microsoft.VisualStudio.Services.WebApi.Patch.Json;
using OutlookBuddy.Areas.AzureDevOps.Shared.AzureDevOpsProxy.Models;

namespace OutlookBuddy.Areas.AzureDevOps.Shared.AzureDevOpsProxy.Services.Implementation
{
    public class WorkItemTrackingClientProxy : IWorkItemTrackingClientProxy
    {
        private const string AzureDevOpsBaseUrl = "https://dev.azure.com/DrMueller/";

        public async Task CreateAsync(WorkItem workItem)
        {
            var client = CreateClient();
            var patchDocument = new JsonPatchDocument
            {
                //new JsonPatchOperation
                //{
                //    Operation = Operation.Add,
                //    Path = "/fields/System.WorkItemType",
                //    Value = "Product Backlog Item"
                //},
                new JsonPatchOperation
                {
                    Operation = Operation.Add,
                    Path = "/fields/System.Title",
                    Value = workItem.Title
                }
            };

            await client.CreateWorkItemAsync(patchDocument, "Fun Project", "Product Backlog Item");
        }

        private WorkItemTrackingHttpClient CreateClient()
        {
            var fileLines = File.ReadAllLines(@"C:\MatthiasStuff\OutlookBuddy\Config.txt");
            var pat = fileLines[0];

            var connection = new VssConnection(new Uri(AzureDevOpsBaseUrl), new VssBasicCredential(string.Empty, pat));
            var witClient = connection.GetClient<WorkItemTrackingHttpClient>();

            return witClient;
        }
    }
}