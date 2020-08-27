using OrienteeringAPI.Data.Base;
using OrienteeringAPI.Repositories.Base;
using OrienteeringAPI.Services.Base;
using OrienteeringModels.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OrienteeringAPI.Services
{
    public class UserService : IUserService
    {
        private ITokenProvider _TokenProvider { get; }
        protected readonly IUserRepository repository;

        public UserService(IUserRepository repository, ITokenProvider tokenProvider)
        {
            _TokenProvider = tokenProvider;
            this.repository = repository;
        }

        public async Task<LoginResultModel> LoginRequest(LoginRequestModel loginRequestModel)
        {
            var users = await repository.GetAll();
            var user = users.Single(u => u.Login == loginRequestModel.Login);
            LoginResultModel loginResult = new LoginResultModel();

            if (user == null)
                return null;

            if (loginRequestModel.Password == user.Password)
            {
                loginResult.Login = user.Login;
                loginResult.Profil = user.Profil;
                loginResult.Token = _TokenProvider.GenerateJwtToken(user.Login);
            }

            return loginResult;
        }
    }
}
