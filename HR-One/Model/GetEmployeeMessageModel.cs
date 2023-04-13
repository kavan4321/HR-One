
using HR_One.EndPoint;
using HR_One.HttpModel;
using HR_One.Table;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace HR_One.Model
{
    public class GetEmployeeMessageModel
    {
        private GetEmployeeMessageEndPoint _getEmployeeMessageEndPoint;

        public int Id { get; set; }
      
        public List<MessageDetail> MessageDetails { get; set; }
        public GetEmployeeMessageModel()
        {
            _getEmployeeMessageEndPoint = new GetEmployeeMessageEndPoint();
        }


        public async Task<ErrorResult> GetEmployeeMessageDetailsAsync()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                _getEmployeeMessageEndPoint.Id = Id;
                var responce = await _getEmployeeMessageEndPoint.ExecuteAsync();
                if (responce.IsSuccessStatusCode)
                {
                    var data = await responce.Content.ReadAsStringAsync();
                    var message = JsonConvert.DeserializeObject<EmployeeMessageResponceModel>(data);
                    MessageDetails = message.MessageDetails;
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
