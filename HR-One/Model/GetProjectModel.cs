
using HR_One.EndPoint;
using HR_One.HttpModel;
using HR_One.Table;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace HR_One.Model
{
    public class GetProjectModel
    {
        private GetProjectEndPoint _getProjectEndPoint;    
        public List<ProjectDetail> ProjectDetails { get; set; }
      
        public GetProjectModel()
        {
            _getProjectEndPoint = new GetProjectEndPoint();
        }

        public async Task<ErrorResult> GetProjectDetailsAsync()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var response = await _getProjectEndPoint.ExecuteAsync();
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var employee = JsonConvert.DeserializeObject<ProjectResponceModel>(data);
                    ProjectDetails = employee.ProjectDetails;
                    return new ErrorResult()
                    {
                        IsSuccess = true
                    };
                }
                else
                {
                    return new ErrorResult()
                    {
                        IsSuccess = false,
                        Message = "Somthing went wrong"
                    };
                }
            }
            else
            {
                return new ErrorResult()
                {
                    IsSuccess = false,
                    IsInternetError = false,
                    Message = "No Internet Connection"
                };
            }
        }

    }
}
