using System;
using System.Threading.Tasks;
using System.Web.Http;
using MindServer.Domain.ActionResults;
using MindServer.Domain.DataContracts;
using MindServer.EF;
using MindServer.Services.Interfaces;

namespace MindServer.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IHttpActionResult Get()
        {
            var temp = new MindServerDbContext();
            return Ok(temp.Users);
        }

        public async Task<IHttpActionResult> SignUp(AccountSignUpRequest accountSignUpRequest)
        {
            if (!ModelState.IsValid||string.IsNullOrWhiteSpace(accountSignUpRequest.Username) || string.IsNullOrWhiteSpace(accountSignUpRequest.Password)) return BadRequest();
            try
            {
                var response = await _accountService.UserSignUp(accountSignUpRequest);
                if (response.Success)
                {
                    return Ok(response);
                }
                return this.BadRequestResponse(response);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        public async Task<IHttpActionResult> LogIn(AccountLogInRequest accountLogInRequest)
        {
            if (!ModelState.IsValid || string.IsNullOrWhiteSpace(accountLogInRequest.EmailAddress) || string.IsNullOrWhiteSpace(accountLogInRequest.Password)) return BadRequest();
            try
            {
                var response = await _accountService.UserLogIn(accountLogInRequest);
                if (response.Success)
                {
                    return Ok(response);
                }
                return this.BadRequestResponse(response);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        public async Task<IHttpActionResult> LogOut(AccountLogOutRequest accountLogOutRequest)
        {
            if (!ModelState.IsValid || string.IsNullOrWhiteSpace(accountLogOutRequest.EmailAddress)) return BadRequest();
            try
            {
                var response = await _accountService.UserLogOut(accountLogOutRequest);
                if (response.Success)
                {
                    return Ok(response);
                }
                return this.BadRequestResponse(response);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}