using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Wrappers.Responses
{
    public class BaseResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("success")]
        public bool Success { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
