using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadSheddingApp.Configuration
{
    public class ConstantSettings : ISettings
    {
        public string AzureSearchEndPoint { get => "<Your Azure Cognitive Search Endpoint>"; }
        public string AzureSearchKey { get => "<Your Azure Cognitive Search Key>"; }
        public string AzureOpenAiEndPoint { get => "<Your Azure Open AI Endpoint>"; }
        public string AzureOpenAiKey { get => "<Your Azure Open AI AP Key>"; }
    }
}
