
using HR_One.HttpModel;
using HR_One.Interface;
using Refit;

namespace HR_One.EndPoint
{
    public class EditMessageEndPoint
    {
        public int Id { get; set; }
        public AddMessageRequestModel EditMessageRequsetModel { get; set; }
        public async Task<HttpResponseMessage> ExecuteAsync()
        {
            return await RestService.
                For<IEmployeeProjectApi>("https://api.onlinewebtutorblog.com").
                EditMessage(EditMessageRequsetModel, Id);
                
        }
    }
}
