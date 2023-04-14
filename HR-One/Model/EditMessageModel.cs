
using HR_One.EndPoint;
using HR_One.HttpModel;
using HR_One.Table;
using HR_One.ViewModel.ViewModelEdit;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace HR_One.Model
{
    public class EditMessageModel
    {
        private EditMessageEndPoint _editMessageEndPoint;
        
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int MessageStutus { get; set; }

        public EditMessageModel()
        {
            _editMessageEndPoint = new EditMessageEndPoint();
        }

        public async Task<ErrorResult> EditMessageAsync()
        {
           
            if (CrossConnectivity.Current.IsConnected)
            {
                var reqestModel = new AddMessageRequestModel()
                {
                    ProjectId = ProjectId,
                    Title = Title,
                    Body = Body,
                    MessageStatus = MessageStutus
                };
                _editMessageEndPoint.Id = Id;
                _editMessageEndPoint.EditMessageRequsetModel = reqestModel;
                var responce = await _editMessageEndPoint.ExecuteAsync();

                if (responce.IsSuccessStatusCode)
                {
                    var data = await responce.Content.ReadAsStringAsync();
                    var editdata = JsonConvert.DeserializeObject<EditMessageResponceModel>(data);
                    return new ErrorResult()
                    {
                        IsSuccess = true,
                        Message = editdata.Msg
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
