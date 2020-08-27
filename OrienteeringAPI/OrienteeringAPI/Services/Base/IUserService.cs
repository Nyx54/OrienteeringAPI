using OrienteeringModels.Models;
using System.Threading.Tasks;

namespace OrienteeringAPI.Services.Base
{
    public interface IUserService
    {
        Task<LoginResultModel> LoginRequest(LoginRequestModel loginRequestModel);
    }
}
