using System.Net;
using System.Text.Json.Serialization;

namespace Movie.API.Models.Base
{
    public class Response<T>
    {
        public T Data { get; set; }
        public List<String> Errors { get; set; }
        public int StatusCode { get; set; }

        public static Response<T> Success(int statusCode, T data)
        {
            return new Response<T> { Data = data, StatusCode = statusCode };
        }
        public static Response<T> Success(int statusCode)
        {
            return new Response<T> { StatusCode = statusCode };
        }
        public static Response<T> Fail(List<String> errors, int statusCode)
        {
            return new Response<T> { StatusCode = statusCode, Errors = errors };
        }
        public static Response<T> Fail(string error, int statusCode)
        {
            return new Response<T> { StatusCode = statusCode, Errors = new List<string> { error } };
        }
    }
}
