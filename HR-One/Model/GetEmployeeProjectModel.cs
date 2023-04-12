
using HR_One.EndPoint;
using HR_One.HttpModel;
using HR_One.Table;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace HR_One.Model
{
    public class GetEmployeeProjectModel
    {
        private GetEmployeeProjectEndPoint _getEmployeeProjectEndPoint;
        public int Id { get; set; }
        public List<EmployeeProjectDetail> EmployeeProjectDetails { get; set; }

        public GetEmployeeProjectModel()
        {
            _getEmployeeProjectEndPoint = new GetEmployeeProjectEndPoint();
        }

        public async Task<ErrorResult> GetEmployeeProjectDetailsAsync()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                _getEmployeeProjectEndPoint.Id = Id;
                var responce = await _getEmployeeProjectEndPoint.ExecuteAsync();
                if (responce.IsSuccessStatusCode)
                {
                    var data = await responce.Content.ReadAsStringAsync();
                    var employeeProject = JsonConvert.DeserializeObject<EmployeeProjectResponceModel>(data);
                    EmployeeProjectDetails = employeeProject.EmployeeProjectDetails;
                    return new ErrorResult()
                    {
                        IsSuccess = true,
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
                    IsInternetError = true,
                    Message = "No Internet Connection"
                };
            }
        }

    }
}
