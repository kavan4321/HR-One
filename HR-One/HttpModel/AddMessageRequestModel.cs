
using Newtonsoft.Json;

namespace HR_One.HttpModel
{
    public class AddMessageRequestModel
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int MessageStatus { get; set; }
    }
}
