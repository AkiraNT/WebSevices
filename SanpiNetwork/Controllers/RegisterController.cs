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
    public class RegisterController : ApiController
    {
        [HttpPost]
        [Route("api/v1/Account/Register")]
        public HttpResponseMessage Register([FromBody] object value)
        {
            object result = new object();
            try
            {
                if (value == null)
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
                    if (dic == null)
                    {
                        result = new
                        {
                            Status = -1,
                            Message = "Lỗi dữ liệu!"
                        };
                        goto outer;
                    }
                    TblAccount account = AccountsManager.GetAccountByEmail(dic.Email.Value);
                    if (account != null)
                    {
                        result = new
                        {
                            Status = -1,
                            Message = "Email đã được sử dụng!"
                        };
                        goto outer;
                    }
                    account = new TblAccount();
                    account.Email = dic.Email.Value;
                    account.Phone = dic.Phone.Value;
                    account.Password = SecurityHelpers.GetMd5Hash(dic.Password.Value);
                    account.FullName = dic.FullName.Value;
                    account = AccountsManager.Insert(account);
                    if (account == null)
                    {
                        result = new
                        {
                            Status = -1,
                            Message = "Hệ thống đang bảo trì!"
                        };
                        goto outer;
                    }
                    result = new
                    {
                        Status = 1,
                        Message = "Đăng ký thành công!",
                        Items = new
                        {
                            Token = SecurityHelpers.EnscryptAES(account.Id.ToString()),
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
                    Message = "Hệ thống đang bảo trì!"
                };
            }
        outer:
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(result), Encoding.UTF8, "application/json");
            return response;
        }
    }
}
