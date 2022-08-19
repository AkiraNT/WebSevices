using Newtonsoft.Json;
using SanpiNetwork.Commons;
using SanpiNetwork.Helpers;
using SweetCMS.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace SanpiNetwork.Controllers
{
    public class SignInController : ApiController
    {
        [HttpPost]
        [Route("api/v1/Account/SignIn")]
        public HttpResponseMessage SignIn([FromBody] object value)
        {
            object result= new object();
            try
            {
                if(value == null)
                {
                    result = new
                    {
                        Status = -1,
                        Message = "Lỗi dữ liệu!"
                    };
                    goto outer;
                }
                try
                {
                    dynamic dic = JsonConvert.DeserializeObject<dynamic>(value.ToString());
                    if(dic == null)
                    {
                        result = new
                        {
                            Status = -1,
                            Message = "Lỗi dữ liệu!"
                        };
                        goto outer;
                    }
                    TblAccount account = AccountsManager.GetAccountByEmail(dic.Email.Value);
                    if(account == null || !SecurityHelpers.VerifyMd5Hash(dic.Password.Value, account.Password))
                    {
                        result = new
                        {
                            Status = -1,
                            Message = "Tài khoản hoặc mật khẩu không đúng!"
                        };
                        goto outer;
                    }
                    result = new
                    {
                        Status = 1,
                        Message = "Đăng nhập thành công!",
                        Items= new
                        {
                            account.Id,
                            account.FullName,
                            account.Email,
                            account.Phone,
                            account.TotalPI,
                            account.BalancePI, 
                            account.DepositPI
                        }
                    };
                }
                catch
                {
                    result = new
                    {
                        Status = -1,
                        Message = "Lỗi dữ liệu!"
                    };
                    goto outer;
                }
            }
            catch (Exception exc)
            {
                result = new
                {
                    Status = -1,
                    Message = "Lỗi!"
                };
            }
            outer:
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(result), Encoding.UTF8, "application/json");
            return response;
        }
    }
}
