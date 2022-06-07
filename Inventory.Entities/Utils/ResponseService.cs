using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities.Utils
{
    public class ResponseService<T>
    {

        public ResponseService(bool hasError, string Message, HttpStatusCode statusCode, T Content)
        {
            this.HasError = hasError;
            this.Message = Message;
            this.StatusHttp = statusCode;
            this.Content = Content;
        }

        public bool HasError { get; set; }
        public string Message { get; set; }
        public HttpStatusCode StatusHttp { get; set; } = HttpStatusCode.OK;
        public T Content { get; set; }
    }
}
