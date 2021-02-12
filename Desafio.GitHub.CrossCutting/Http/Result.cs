using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.GitHub.CrossCutting.Http
{
    public class Result<T>
    {
        public T Value { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
