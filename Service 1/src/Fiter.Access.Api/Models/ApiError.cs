using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Exceptions;
using Domain.Model.Validations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Api.Models
{
    public class ApiError
    {
        private ModelStateDictionary _modelState;

        public int Code { get; set; }
        public string Message { get; set; }
        public string Detail { get; set; }
        public string InnerException { get; set; }
        public List<ValidationError> Errors { get; set; }


        public ApiError()
        {
        }

        public ApiError(string message) => this.Message = message;

        public ApiError(ApiException ex)
        {
            Message = ex.Message;
            Errors = ex.Errors;
        }

        public ApiError(int code, string message)
        {
            Code = code;
            this.Message = message;
        }


        public ApiError(string message, string details)
        {
            this.Message = message;
            this.Detail = details;
        }

        public ApiError(string message, ModelStateDictionary modelState)
        {
            Message = message;
            Errors = modelState.Keys
                .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
                .ToList();
        }

        public ApiError(string message, Exception ex, bool debbugMode)
        {
            Code = ex.HResult;
            Message = (debbugMode) ? ex.Message : message;
            InnerException = (debbugMode && ex.InnerException != null) ? ex.InnerException.Message : string.Empty;
            Detail = (debbugMode && ex.StackTrace != null) ? ex.StackTrace : string.Empty;
        }

        public ApiError(ModelStateDictionary modelState)
        {
            this._modelState = modelState;
        }
    }
}
