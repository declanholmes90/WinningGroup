using FluentValidation;
using MediatR;

namespace LeapActivityTracker.Core.Common.Behaviours
{
    public class RequestValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly IEnumerable<IValidator<TRequest>> _validatorCollection;

        public RequestValidationBehaviour(IEnumerable<IValidator<TRequest>> validatorCollection)
        {
            _validatorCollection = validatorCollection;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var failures = _validatorCollection
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Count != 0)
            {
                throw new ValidationException(failures.FirstOrDefault().ToString());
            }

            return await next();
        }
    }
}
