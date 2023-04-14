
using HR_One.EndPoint;
using HR_One.HttpModel;
using HR_One.Table;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace HR_One.Model
{
    public class AddMessageModel
    {
        private AddMessageEndPoint _addMessageEndPoint;
        public string Title { get; set; }
        public string Body { get; set; }

        public AddMessageModel()
        {
            _addMessageEndPoint = new AddMessageEndPoint();
        }

        public async Task<ErrorResult> AddMessageAsync()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var reqestModel = new AddMessageRequestModel()
                {
                    Title= Title,
                    Body = Body
                };
                _addMessageEndPoint.AddMessageRequestModel= reqestModel;
                var responce = await _addMessageEndPoint.ExecuteAsync();
               
                if (responce.IsSuccessStatusCode)
                {
                    var data = await responce.Content.ReadAsStringAsync();
                    var addMessage = JsonConvert.DeserializeObject<EditMessageResponceModel>(data);
                    return new ErrorResult()
                    {
                        IsSuccess = true,
                        Message = addMessage.Msg
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
