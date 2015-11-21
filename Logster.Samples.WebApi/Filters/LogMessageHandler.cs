using System;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Logster.Client.Web;
using Logster.Core;

namespace Logster.Samples.WebApi.Filters
{
    public class LogMessageHandler : DelegatingHandler
    {
        private readonly AssemblyName _assemblyName;

        public LogMessageHandler()
        {
            _assemblyName = GetType().Assembly.GetName();
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            await Log(request);

            var response = await base.SendAsync(request, cancellationToken);

            await Log(response);

            return response;
        }

        private async Task Log(HttpResponseMessage response)
        {
            var user = GetUser(response.RequestMessage);
            var body = await FormatBody(response.Content);
            var message = "Response: " + body;

            Log(message, user, response.RequestMessage.RequestUri);
        }

        private async Task Log(HttpRequestMessage request)
        {
            var user = GetUser(request);
            var body = await FormatBody(request.Content);
            var message = "Request: " + body;

            Log(message, user, request.RequestUri);
        }

        private void Log(string value, string user, Uri url)
        {
            // Logster.io!!!
            var message = new LogMessage
                              {
                                  Application = _assemblyName.Name,
                                  Category = url.ToString(),
                                  Message = value,
                                  Severity = Severity.Trace,
                                  User = user
                              };

            var log = new LogsterWebLog();
            log.LogInBackground(message);
        }

        private string GetUser(HttpRequestMessage message)
        {
            return message.GetRequestContext().Principal.Identity.Name;
        }

        private async Task<string> FormatBody(HttpContent content)
        {
            var bytes = await content.ReadAsByteArrayAsync();

            var body = Encoding.UTF8.GetString(bytes);

            return body;
        }
    }
}