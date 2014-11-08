using System;
using System.Threading.Tasks;
using System.Web.Http;
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
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                var sessionToken = await _accountService.UserSignUp(accountSignUpRequest);

                if (string.IsNullOrEmpty(sessionToken))
                {
                    return Ok(new AccountSignUpResponse
                    {
                        Success = false,
                        SessionToken = string.Empty
                    });
                }
                return Ok(new AccountSignUpResponse
                {
                    Success = true,
                    SessionToken = sessionToken
                });
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        public async Task<IHttpActionResult> LogIn(AccountLogInRequest accountLogInRequest)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                var sessionToken = await _accountService.UserLogIn(accountLogInRequest);
                if (string.IsNullOrEmpty(sessionToken))
                {
                    return Ok(new AccountLogInResponse
                    {
                        Success = false,
                        SessionToken = string.Empty
                    });
                }
                return Ok(new AccountLogInResponse
                {
                    Success = true,
                    SessionToken = sessionToken
                });
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public async Task<IHttpActionResult> LogOut(AccountLogOutRequest accountLogOutRequest)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                await _accountService.UserLogOut(accountLogOutRequest);
                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}