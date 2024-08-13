using AutoFixture;
using Shouldly;
using WinningGroup.Core.Activity.Queries;

namespace WinningGroup.UnitTests.ValidatorTests
{
    public class GetSummaryOfProductsValidatorTests
    {
        private readonly GetSummaryOfProductsValidator _sut;
        private readonly Fixture _fixture;
        public GetSummaryOfProductsValidatorTests()
        {
            _sut = new GetSummaryOfProductsValidator();
            _fixture = new Fixture();
        }

        [Fact]
        public void Validation_ShouldFail_WherePriceMaxIsLessThanPriceMin()
        {
            var cmd = _fixture.Build<GetSummaryOfProductsQuery>()
                .With(q => q.PriceMin, 10)
                .With(q => q.PriceMax, 5)
                .With(q => q.RatingMin, 1)
                .With(q => q.RatingMax, 5)

                .Create();

            var results = _sut.Validate(cmd);

            results.IsValid.ShouldBeFalse();
        }

        [Fact]
        public void Validation_ShouldPass_WherePriceMaxIsGreaterThanPriceMin()
        {
            var cmd = _fixture.Build<GetSummaryOfProductsQuery>()
                .With(q => q.PriceMin, 5)
                .With(q => q.PriceMax, 10)
                .With(q => q.RatingMin, 1)
                .With(q => q.RatingMax, 5)
                .Create();

            var results = _sut.Validate(cmd);

            results.IsValid.ShouldBeTrue();
        }

        [Fact]
        public void Validation_ShouldFail_WhereRatingMaxIsLessThanRatingMin()
        {
            var cmd = _fixture.Build<GetSummaryOfProductsQuery>()
                .With(q => q.PriceMin, 5)
                .With(q => q.PriceMax, 10)
                .With(q => q.RatingMin, 5)
                .With(q => q.RatingMax, 2)
                .Create();

            var results = _sut.Validate(cmd);

            results.IsValid.ShouldBeFalse();
        }

        [Fact]
        public void Validation_ShouldPass_WhereRatingMaxIsGreaterThanRatingMin()
        {
            var cmd = _fixture.Build<GetSummaryOfProductsQuery>()
                .With(q => q.PriceMin, 5)
                .With(q => q.PriceMax, 10)
                .With(q => q.RatingMin, 1)
                .With(q => q.RatingMax, 5)
                .Create();

            var results = _sut.Validate(cmd);

            results.IsValid.ShouldBeTrue();
        }
    }
}