using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsUI.Models
{
    public class ResponseNewsModel
    {
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; }
        public List<NewsLight> Data { get; set; }
    }
}
