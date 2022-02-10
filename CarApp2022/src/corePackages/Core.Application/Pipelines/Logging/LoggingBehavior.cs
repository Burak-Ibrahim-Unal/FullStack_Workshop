using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Logging;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
                where TRequest : IRequest<TResponse>, ILoggableRequest
{
    private readonly LoggerServiceBase _loggerServiceBase;
    private readonly IHttpContextAccessor _httpContextAccessor;
    IConfiguration _configuration;
    public LoggingBehavior(LoggerServiceBase loggerServiceBase, IHttpContextAccessor httpContextAccessor)
    {
        _loggerServiceBase = loggerServiceBase;
        _httpContextAccessor = httpContextAccessor;
    }



    public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {

        var logParameters = new List<LogParameter>();
        logParameters.Add(new LogParameter
        {
            Type = request.GetType().Name,
            Value = request
        });




        var logDetail = new LogDetail
        {
            MethodName = next.Method.Name,
            Parameters = logParameters,
            User = (_httpContextAccessor.HttpContext == null ||
                    _httpContextAccessor.HttpContext.User.Identity.Name == null)
                ? "?"
                : _httpContextAccessor.HttpContext.User.Identity.Name
        };



        _loggerServiceBase.Info(JsonConvert.SerializeObject(logDetail));




        return next();



    }




}