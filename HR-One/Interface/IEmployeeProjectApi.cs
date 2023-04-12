
using Refit;

namespace HR_One.Interface
{
    public interface IEmployeeProjectApi
    {
        [Get("/{id}/projects")]
        Task<HttpResponseMessage> GetEmployeeProjectList(int id);
    }
}
