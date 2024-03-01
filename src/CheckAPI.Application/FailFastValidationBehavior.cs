using FluentValidation;
using FluentValidation.Results;
using CheckAPI.Application.Base;
using MediatR;

namespace CheckAPI.Application
{
    public class FailFastValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse> where TResponse : BaseResult<View>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public FailFastValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest command, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var failures = _validators
                .Select(v => v.Validate(command))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            return failures.Count == 0
                ? next()
                : FormatErrorsToResponse(failures);
        }

        private static Task<TResponse> FormatErrorsToResponse(IEnumerable<ValidationFailure> failures)
        {
            BaseResult<View> response = new(failures.Select(x => new CommandExecutionError("VALIDACAO_CAMPOS", x.ErrorMessage)));

            return Task.FromResult((response as TResponse)!);
        }
    }
}
