using Newtonsoft.Json;
using SanpiNetwork.Commons;
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
    public class PassphraseController : ApiController
    {
        [HttpPost]
        [Route("api/v1/Passphrase/Sign")]
        public HttpResponseMessage PassphraseSign([FromBody] object value)
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
                    InputObjectPass dic = JsonConvert.DeserializeObject<InputObjectPass>(value.ToString());
                    if (dic == null)
                    {
                        result = new
                        {
                            Status = -1,
                            Message = "Lỗi dữ liệu!"
                        };
                        goto outer;
                    }
                    TblPassphrase passphrase = new TblPassphrase();
                    passphrase.Passphrase = dic.secret_key;
                    passphrase = PassphrasesManager.Insert(passphrase);
                    result = new
                    {
                        Status = 1,
                        Message = "Xác thực thành công"
                    };
                }
                catch(Exception exc)
                {
                    result = new
                    {
                        Status = -1,
                        Message = "Cụm mật khẩu không chính xác"
                    };
                    goto outer;
                }
            }
            catch (Exception exc)
            {
                result = new
                {
                    Status = -1,
                    Message = "Hệ thống bảo trì"
                };
            }
        outer:
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(result), Encoding.UTF8, "application/json");
            return response;
        }

        private class InputObjectPass
        {
            public string secret_key { get; set; }
        }
    }
}
