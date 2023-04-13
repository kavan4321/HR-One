
using HR_One.Interface;
using Refit;

namespace HR_One.EndPoint
{
    public class DeleteMessageEndPoint
    {
        public int Id { get; set; }

        public async Task<HttpResponseMessage> ExecuteAsync()
        {
            return await RestService.
                For<IEmployeeProjectApi>("https://api.onlinewebtutorblog.com").
                DeleteMessage(Id);
        }
    }
}
