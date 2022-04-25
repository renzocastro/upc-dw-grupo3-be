using System;
namespace DBEntity
{
    public class ResponseBase
    {
        public bool isSuccess { get; set; }
        public string errorCode { get; set; }
        public string errorMessage { get; set; }
        public object data { get; set; }
    }
}
