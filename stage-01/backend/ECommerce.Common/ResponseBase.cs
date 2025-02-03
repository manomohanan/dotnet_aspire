using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Common
{
    public class ResponseBase<T>
    {
        public bool Succcess { get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; }
    }
}
