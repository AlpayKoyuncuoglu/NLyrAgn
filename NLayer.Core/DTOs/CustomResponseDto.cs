using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public class CustomResponseDto<T>
    {
        //error ve success durumları için ayrı ayrı Dto'lar verilmesi yerine custom bir dto olması daha mantıklıdır
        public T Data { get; set; }
        //response'ın body'sinde gerekli değil ancak kod içinde lazım
        [JsonIgnore]
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }
        public static CustomResponseDto<T> Success(int statusCode, T data)
        {
            //static factory method denir
            //factory design pattern
            //ayrı inderface ve class'lar oluşturmak yerine aynı sınıf içerisinde static metodlarla instance'lar tanımlanır
            return new CustomResponseDto<T> { StatusCode = statusCode, Data = data };
        }
        public static CustomResponseDto<T> Success(int statusCode)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode };
        }
        public static CustomResponseDto<T> Fail(int statusCode, List<string> errors)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = errors };
        }
        public static CustomResponseDto<T> Fail(int statusCode, string error)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = new List<string> {error } };
        }

    }
}
