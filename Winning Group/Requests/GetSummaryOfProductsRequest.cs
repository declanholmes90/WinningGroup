namespace WinningGroupAPI.Requests
{
    public class GetSummaryOfProductsRequest
    {
        public double? PriceMin { get; set; }
        public double? PriceMax { get; set; }
        public bool? IsFantastic { get; set; }
        public double? RatingMin { get; set; }
        public double? RatingMax { get; set; }
    }
}
