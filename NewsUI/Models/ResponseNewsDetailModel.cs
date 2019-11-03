using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsUI.Models
{
    public class ResponseNewsDetailModel
    {
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; }
        public News Data { get; set; }
    }
}
