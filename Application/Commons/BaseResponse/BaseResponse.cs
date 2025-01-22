using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commons.Responses
{
    public class BaseResponse<T>
    {
        public bool Success { get; set; } = true;
        public string? Message { get; set; }
        public T? Data { get; set; }

        public BaseResponse(T data, bool success, string? message)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}