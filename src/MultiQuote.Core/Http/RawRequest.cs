using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQuoteApi.Core.Infrastructure.Http
{
    public class RawRequest : BaseRequest
    {
        public string RequestUri { get; set; }
    }
}
