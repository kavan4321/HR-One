
using HR_One.HttpModel;
using Refit;

namespace HR_One.Interface
{
    public interface IEmployeeProjectApi
    {
        [Get("/{id}/projects")]
        Task<HttpResponseMessage> GetEmployeeProjectList(int id);

        [Get("/{id}/messages")]
        Task<HttpResponseMessage> GetMessageList(int id);

      
        [Post("/messages")]
        Task<HttpResponseMessage> AddMessage([Body] AddMessageRequestModel model);

        [Put("/messages/{id}")]
        Task<HttpResponseMessage> EditMessage([Body]AddMessageRequestModel model,int id);

        [Delete("/messages/{id}")]
        Task<HttpResponseMessage> DeleteMessage(int id);
    }
}
