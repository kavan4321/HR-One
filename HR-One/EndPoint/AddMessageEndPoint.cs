
using HR_One.HttpModel;
using HR_One.Interface;
using Refit;

namespace HR_One.EndPoint
{
    public class AddMessageEndPoint
    {
        public AddMessageRequestModel AddMessageRequestModel { get; set; }

        public async Task<HttpResponseMessage> ExecuteAsync()
        {
            return await RestService.
                For<IEmployeeProjectApi>("https://api.onlinewebtutorblog.com").
                AddMessage(AddMessageRequestModel);
        }
    }
}
