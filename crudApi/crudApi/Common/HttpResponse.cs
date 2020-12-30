﻿using System.Net;

namespace crudApi.Common
{
    public class HttpResponse<T>
    {
        public HttpStatusCode statusCode { get; set; }
        public bool IsStatusCodeSuccess { get; set; }
        public T data { get; set; }
        public int? Total { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
