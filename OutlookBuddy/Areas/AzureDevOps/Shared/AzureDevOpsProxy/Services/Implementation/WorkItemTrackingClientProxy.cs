using System;
using System.IO;
using System.Net.Http;
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
        private const string BaseUrl = "https://drmueller.visualstudio.com/";

        public async Task CreateAsync(WorkItem workItem)
        {
            var client = await CreateClientAsync();
            var patchDocument = new JsonPatchDocument
            {
                new JsonPatchOperation
                {
                    Operation = Operation.Add,
                    Path = "/fields/System.Title",
                    Value = workItem.Title
                },
                new JsonPatchOperation
                {
                    Operation = Operation.Add,
                    Path = "/fields/System.Description",
                    Value = workItem.Description
                }
            };

            await client.CreateWorkItemAsync(patchDocument, "Fun Project", "Product Backlog Item");
        }

        private async Task<WorkItemTrackingHttpClient> CreateClientAsync()
        {
            var trs = new HttpClient();
            var res = await trs.GetAsync("https://httpbin.org/get");

            var fileLines = File.ReadAllLines(@"C:\MatthiasStuff\OutlookBuddy\Config.txt");
            var pat = fileLines[0];

            var connection = new VssConnection(new Uri(BaseUrl), new VssBasicCredential(string.Empty, pat));
            await connection.ConnectAsync();
            var witClient = await connection.GetClientAsync<WorkItemTrackingHttpClient>();

            return witClient;
        }
    }
}