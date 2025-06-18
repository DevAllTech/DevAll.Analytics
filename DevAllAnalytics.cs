using System.Text;
using System.Text.Json;

namespace DevAll.Analytics
{
    public enum DevAllEventType { Error, Warning, Info, Log, Metric, Custom }
    public enum DevAllEnvironment { Dev, Staging, Prod }

    public class DevAllAnalytics
    {
        private readonly string _projectToken;
        private readonly HttpClient _httpClient;

        public DevAllAnalytics(string projectToken)
        {
            _projectToken = projectToken ?? throw new ArgumentNullException(nameof(projectToken));
            _httpClient = new HttpClient();
        }

        public async Task TrackEventAsync(
            DevAllEventType type,
            DevAllEnvironment environment,
            string category,
            string message,
            object payload,
            object deviceInfo = null,
            DateTime? timestamp = null)
        {
            var eventData = new
            {
                timestamp = (timestamp ?? DateTime.UtcNow).ToString("o"),
                type = type.ToString().ToLower(),
                environment = environment.ToString().ToLower(),
                category,
                message,
                payload,
                deviceInfo = deviceInfo ?? DevAllSystemInfo.GetDefaultDeviceInfo(),
                ip = "0.0.0.0"
            };

            var content = new StringContent(JsonSerializer.Serialize(eventData), Encoding.UTF8, "application/json");
            content.Headers.Add("x-project-token", _projectToken);

            await _httpClient.PostAsync("https://api-logs.devalltech.com.br/api/v1/events", content);
        }
    }
}
