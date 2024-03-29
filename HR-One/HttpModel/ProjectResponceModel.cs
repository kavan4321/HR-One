﻿
using Newtonsoft.Json;

namespace HR_One.HttpModel
{
    public class ProjectResponceModel
    {
        [JsonProperty("error")]
        public int Error { get; set; }

        [JsonProperty("msg")]
        public string Msg { get; set; }

        [JsonProperty("data")]
        public List<ProjectDetail> ProjectDetails { get; set; }
    }
    public class ProjectDetail
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("employeeId")]
        public int EmployeeId { get; set; }

        [JsonProperty("project_domain")]
        public string ProjectDomain { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("budget")]
        public string Budget { get; set; }

        [JsonProperty("time_estimate")]
        public string TimeEstimate { get; set; }
    }
}
