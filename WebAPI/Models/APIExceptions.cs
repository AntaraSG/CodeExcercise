using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace WebAPI.Models
{
    public class APIExceptions : Exception
    {
        public ErrorCategory ErrorCode = ErrorCategory.InvalidOperationException;
        public new string Message;
        
        public APIExceptions(Exception exception)
        {
            Message = exception.Message;
            switch (exception.GetType().Name.ToUpper())
            {
                case "IOEXCEPTION":
                    ErrorCode = ErrorCategory.IOException;
                    break;
                case "INDEXOUTOFRANGEEXCEPTION":
                    ErrorCode = ErrorCategory.IndexOutOfRangeException;
                    break;
                case "ARRAYTYPEMISMATCHEXCEPTION":
                    ErrorCode = ErrorCategory.ArrayTypeMismatchException;
                    break;
                case "NULLREFERENCEEXCEPTION":
                    ErrorCode = ErrorCategory.NullReferenceException;
                    break;
                case "DIVIDEBYZEROEXCEPTION":
                    ErrorCode = ErrorCategory.DivideByZeroException;
                    break;
                case "INVALIDCASTEXCEPTION":
                    ErrorCode = ErrorCategory.InvalidCastException;
                    break;
                case "OUTOFMEMORYEXCEPTION":
                    ErrorCode = ErrorCategory.OutOfMemoryException;
                    break;
                case "STACKOVERFLOWEXCEPTION":
                    ErrorCode = ErrorCategory.StackOverflowException;
                    break;
                case "SQLEXCEPTION":
                    ErrorCode = ErrorCategory.SqlException;
                    break;
                default:
                    ErrorCode = ErrorCategory.InvalidOperationException;
                    break;
            }
        }
        public APIExceptions(Exception exception, HttpStatusCode statusCode)
        {
            Message = exception.Message;
            switch (statusCode.ToString().ToUpper())
            {
                case "REQUESTTIMEOUT":
                    ErrorCode = ErrorCategory.RequestTimeout;
                    break;
                case "FORBIDDEN":
                    ErrorCode = ErrorCategory.ApplicationKeyForbidden;
                    break;
                case "BADREQUEST":
                    ErrorCode = ErrorCategory.BadRequest;
                    break;
                case "UNAUTHORIZED":
                    ErrorCode = ErrorCategory.UserCredentialsUnauthorized;
                    break;
                default:
                    ErrorCode = ErrorCategory.InvalidOperationException;
                    break;
            }
        }

        public APIExceptions(string message)
            : base(message)
        {
            ErrorCode = ErrorCategory.InvalidOperationException;
            Message = message;
        }

        public APIExceptions(string message, ErrorCategory code)
            : base(message)
        {
            ErrorCode = code;
            Message = message;
        }

        public enum ErrorCategory
        {
            NoException = 0,
            InvalidOperationException = 1,
            NoCountException = 2,
            IOException = 3,
            IndexOutOfRangeException = 4,
            ArrayTypeMismatchException = 5,
            NullReferenceException = 6,
            DivideByZeroException = 7,
            InvalidCastException = 8,
            OutOfMemoryException = 9,
            StackOverflowException = 10,
            SqlException = 11,
            OtherException = 12,
            InvalidConfiguration = 13,
            PasswordRule = 14,
            BadRequest = 400,
            UserCredentialsUnauthorized = 401,
            ApplicationKeyForbidden = 403,
            RequestTimeout = 408
        }
    }
}