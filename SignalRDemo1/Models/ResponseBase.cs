using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRDemo1.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ResponseBase<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Code { get; set; }
        public T Data { get; set; }
    }
}
