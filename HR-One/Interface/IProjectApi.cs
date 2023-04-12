
using Refit;

namespace HR_One.Interface
{
    public interface IProjectApi
    {
        [Get("/projects")]
        Task<HttpResponseMessage> GetProjectList();
    }
}
