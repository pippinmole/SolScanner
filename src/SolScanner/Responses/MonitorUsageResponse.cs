using System.Text.Json.Serialization;

namespace SolScanner.Responses;

public sealed class MonitorUsageResponse
{
    [JsonPropertyName("remaining_cus")]
    public int RemainingCus { get; set; }

    [JsonPropertyName("usage_cus")]
    public int UsageCus { get; set; }

    [JsonPropertyName("total_requests_24h")]
    public int TotalRequests24h { get; set; }

    [JsonPropertyName("success_rate_24h")]
    public double SuccessRate24h { get; set; }

    [JsonPropertyName("total_cu_24h")]
    public int TotalCu24h { get; set; }
}