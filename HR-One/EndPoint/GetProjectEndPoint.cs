
using HR_One.Interface;
using Refit;

namespace HR_One.EndPoint
{
    public class GetProjectEndPoint
    {
        public async Task<HttpResponseMessage> ExecuteAsync()
        {
            return await RestService.
                For<IProjectApi>("https://api.onlinewebtutorblog.com").
                GetProjectList();
        }
    }
}
