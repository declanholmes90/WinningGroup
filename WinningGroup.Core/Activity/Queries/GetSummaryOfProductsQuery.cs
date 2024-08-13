using MediatR;

namespace WinningGroup.Core.Activity.Queries
{
    public class GetSummaryOfProductsQuery : IRequest<GetSummaryOfProductsViewModel>
    {
        public double? PriceMin { get; set; }
        public double? PriceMax { get; set; }
        public bool? IsFantastic { get; set; }
        public double? RatingMin { get; set; }
        public double? RatingMax { get; set; }
    }
}
