using OrienteeringAPI.Data.Base;
using OrienteeringAPI.Repositories;
using OrienteeringAPI.Services.Base;
using OrienteeringModels.Dtos;
using OrienteeringModels.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrienteeringAPI.Services
{
    public class UserService : AbstractBaseService<UserRepository, OrienteeringUser>
    {
        private ITokenProvider _TokenProvider { get; }

        public UserService(UserRepository repository, ITokenProvider tokenProvider) : base(repository)
        {
            _TokenProvider = tokenProvider;
        }

        public async Task<LoginResultModel> LoginRequest(LoginRequestModel loginRequestModel)
        {
            var users = await base.GetAll();
            var user = users.Single(u => u.Login == loginRequestModel.Login);
            LoginResultModel loginResult = new LoginResultModel();

            if (user == null)
                return null;

            if (loginRequestModel.Password == user.Password)
            {
                loginResult.Token = _TokenProvider.GenerateJwtToken(user.Login);
            }

            return loginResult;
        }
    }
}
