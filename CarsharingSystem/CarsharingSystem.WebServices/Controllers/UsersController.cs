
namespace CarsharingSystem.WebServices.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;

    using CarsharingSystem.Data;
    using CarsharingSystem.Model;
    using CarsharingSystem.WebServices.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Testing;

    [System.Web.Http.Authorize]
    [RoutePrefix("api/user")]
    public class UsersController : ApiController
    {
        private readonly ApplicationDbContext db;
        private ApplicationUserManager userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return this.userManager ?? this.Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        // POST api/user/register
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        [Route("register")]
        public async Task<IHttpActionResult> RegisterUser(UserAccountRegisterInputModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Invalid user data");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            ApplicationUser user = null;

            switch (model.UserType)
            {
                case UserType.Driver:
                    user = new Driver
                        {
                            UserName = model.Username
                        };
                break;

                case UserType.Passenger:
                    user = new Passenger
                        {
                            UserName = model.Username
                        };
                break;
            }

            user.RegistrationDate = DateTime.Now;

            var identityResult = await this.UserManager.CreateAsync(user, model.Password);

            if (!identityResult.Succeeded)
            {
                return this.GetErrorResult(identityResult);
            }

            // Auto login after registrаtion (successful user registration should return access_token)
            var loginResult = await this.LoginUser(new UserAccountInputModel()
            {
                Username = model.Username,
                Password = model.Password
            });
            return loginResult;
        }

        // POST api/user/login
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        [Route("login")]
        public async Task<IHttpActionResult> LoginUser(UserAccountInputModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Invalid user data");
            }

            // Invoke the "token" OWIN service to perform the login (POST /api/token)
            var testServer = TestServer.Create<Startup>();

            var requestParams = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", model.Username),
                new KeyValuePair<string, string>("password", model.Password)
            };
            var requestParamsFormUrlEncoded = new FormUrlEncodedContent(requestParams);
            var tokenServiceResponse = await testServer.HttpClient.PostAsync(
                Startup.TokenEndpointPath, requestParamsFormUrlEncoded);

            return this.ResponseMessage(tokenServiceResponse);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return this.InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        this.ModelState.AddModelError("", error);
                    }
                }

                if (this.ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return this.BadRequest();
                }

                return this.BadRequest(this.ModelState);
            }

            return null;
        }
    }
}
