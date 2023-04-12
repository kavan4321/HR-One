
using HR_One.EndPoint;
using HR_One.HttpModel;
using HR_One.Table;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace HR_One.Model
{
    public class GetEmployeeModel
    {
        private GetEmployeeEndpoint _getEmployeeEndpoint;
        public List<EmployeeDetail> EmployeeDetails { get; set; }

        public GetEmployeeModel()
        {
            _getEmployeeEndpoint = new GetEmployeeEndpoint();
        }

        public async Task<ErrorResult> GetEmployeeDetailsAsync()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var response=await _getEmployeeEndpoint.ExecuteAsync();
                if (response.IsSuccessStatusCode)
                {
                    var data=await response.Content.ReadAsStringAsync();  
                    var employee=JsonConvert.DeserializeObject<EmployeeResponceModel>(data);
                    EmployeeDetails=employee.EmployeeDetails;
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
