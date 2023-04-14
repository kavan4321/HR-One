
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace HR_One.HttpModel
{
    public class AddMessageRequestModel
    {
        [JsonPropertyName("projectId")]
        public int ProjectId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("body")]
        public string Body { get; set; }

        [JsonPropertyName("message_status")]
        public int MessageStatus { get; set; }
    }
}
