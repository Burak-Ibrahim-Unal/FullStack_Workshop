using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Exceptions
{
    public class ExceptionMiddleware
    {
        public RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {

                await HandleExceptionAsync(context, e);
            }


        }

        private Task HandleExceptionAsync(HttpContext context, Exception e)
        {
            context.Response.ContentType = "application/json";
            object errors = null;

            if (e.GetType() == typeof(ValidationException))
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                errors = ((ValidationException)e).Errors;

                return context.Response.WriteAsync(new ValidationProblemDetails
                {
                    Status = StatusCodes.Status400BadRequest,
                    Type = "https//example.com/probs/validation",
                    Title = "Validation Error(s)",
                    Detail = "",
                    Instance = "",
                    Errors = errors

                }.ToString());


            }       
            
            if (e.GetType() == typeof(BusinessException))
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                return context.Response.WriteAsync(new BusinessProblemDetails
                {
                    Status = StatusCodes.Status400BadRequest,
                    Type = "https//example.com/probs/business",
                    Title = "Business Error(s)",
                    Detail = e.Message,
                    Instance = "",

                }.ToString());  
            }

            return context.Response.WriteAsync(new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Type = "https//example.com/probs/internal",
                Title = "Internal Error(s)",
                Detail = e.Message,
                Instance = "",

            }.ToString());


        }
    }
}
