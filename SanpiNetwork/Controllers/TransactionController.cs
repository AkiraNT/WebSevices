﻿using Newtonsoft.Json;
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
    public class TransactionController : ApiController
    {
        [HttpPost]
        [Route("api/v1/Transaction/Check")]
        public HttpResponseMessage Check([FromBody] object value)
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
                    TblTransaction transaction = TransactionsManager.GetTransactionByCode(dic.Code.Value);
                    if(transaction == null)
                    {
                        result = new
                        {
                            Status = -1,
                            Message = "Không tìm thấy thông tin giao dịch trên hệ thống!"
                        };
                        goto outer;
                    }
                    result = new
                    {
                        Status = 1,
                        Message = "Success",
                        Items = new
                        {
                            transaction.Id,
                            transaction.Code,
                            transaction.Qty,
                            transaction.Rate,
                            transaction.Amount,
                            transaction.Type,
                            transaction.Status,
                            transaction.DateX
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

        [HttpPost]
        [Route("api/v1/Transaction/Create")]
        public HttpResponseMessage Create([FromBody] object value)
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
                    TblTransaction transaction = new TblTransaction();
                    transaction.Code = (string)dic.Code.Value;
                    transaction.Qty = (decimal)dic.Qty.Value;
                    transaction.Rate = (decimal)dic.Rate.Value;
                    transaction.Amount = transaction.Qty * transaction.Rate;
                    transaction.Type = dic.Type.Value;
                    transaction.Status = "Pending";
                    transaction.DateX = DateTime.UtcNow;
                    if (string.IsNullOrEmpty(transaction.Code))
                        transaction.Code = string.Format("TS-{0}", DateTime.Now.Ticks);
                    transaction = TransactionsManager.Insert(transaction);
                    if (transaction == null)
                    {
                        result = new
                        {
                            Status = -1,
                            Message = "Lỗi dữ liệu!"
                        };
                        goto outer;
                    }
                    result = new
                    {
                        Status = 1,
                        Message = "Success",
                        Items = new
                        {
                            transaction.Id,
                            transaction.Code,
                            transaction.Qty,
                            transaction.Rate,
                            transaction.Amount,
                            transaction.Type,
                            transaction.Status,
                            transaction.DateX
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
