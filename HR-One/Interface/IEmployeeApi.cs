
using Refit;

namespace HR_One.Interface
{
    public interface IEmployeeApi
    {
        [Get("/employees")]
        Task<HttpResponseMessage> GetEmployeeList();
    }
}
