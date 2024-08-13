using FluentValidation;

namespace WinningGroup.Core.Activity.Queries
{
    public class GetSummaryOfProductsValidator : AbstractValidator<GetSummaryOfProductsQuery>
    {
        public GetSummaryOfProductsValidator()
        {
            RuleFor(q => q.PriceMin).LessThan(q => q.PriceMax).When(q => q.PriceMax.HasValue).WithMessage("Maximum Price cannot be less the Minimum Price.");
            RuleFor(q => q.RatingMin).LessThan(q => q.RatingMax).When(q => q.RatingMin.HasValue).WithMessage("Maximum Rating cannot be less the Minimum Rating.");
        }
    }
}
