using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMSystem.Models
{
    public class ResponseModel
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public object Data { get; set; }
        public void SetSuccess(string message = "成功")
        {
            Code = 200;
            Message = message;
        }
        public void SetFailed(string message = "失败")
        {
            Message = message;
            Code = 999;
        }

        public void SetData(object data)
        {
            Data = data;
        }
    }
}
