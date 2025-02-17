﻿using OpenAI.Net.Models.Responses;

namespace OpenAI.Net.Models.OperationResult
{
    public class OperationResult<T>
    {
        public OperationResult(T? result)
        {
            Result = result;
        }

        public OperationResult(Exception exception, string? errorMessaage = null)
        {
            Exception = exception;
            ErrorMessage = errorMessaage ?? exception.Message;
        }
        public T? Result { get; set; }
        public string ErrorMessage { get; set; }
        public Exception Exception { get; set; }
        public bool IsSuccess => Exception == null;

        public static implicit operator OperationResult<T>(T? result) => new OperationResult<T>(result);
#pragma warning disable CS8603 // Possible null reference return.
        public static implicit operator T(OperationResult<T> result) => result.Result;
#pragma warning restore CS8603 // Possible null reference return.
    }
}
