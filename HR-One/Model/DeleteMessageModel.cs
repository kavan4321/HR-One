
using HR_One.EndPoint;
using HR_One.HttpModel;
using HR_One.Table;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace HR_One.Model
{
    public class DeleteMessageModel
    {
        private DeleteMessageEndPoint _deleteMessageEndPoint;

        public int Id { get;set; }
        public DeleteMessageModel()
        {
            _deleteMessageEndPoint = new DeleteMessageEndPoint();
        }

        public async Task<ErrorResult> DeleteMessageAsync()
        {
            if (CrossConnectivity.Current.IsConnected)
            {

                _deleteMessageEndPoint.Id = Id;
                var responce = await _deleteMessageEndPoint.ExecuteAsync();

                if (responce.IsSuccessStatusCode)
                {
                    var data = await responce.Content.ReadAsStringAsync();
                    var deleteMessage = JsonConvert.DeserializeObject<EmployeeMessageResponceModel>(data);
                    return new ErrorResult()
                    {
                        IsSuccess = true,
                        Message = deleteMessage.Msg
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
