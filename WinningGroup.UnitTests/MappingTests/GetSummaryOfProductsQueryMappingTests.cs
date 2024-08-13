using AutoFixture;
using AutoMapper;
using Shouldly;
using WinningGroup.Core.Activity.Queries;
using WinningGroupAPI.Requests;

namespace WinningGroup.UnitTests.MappingTests
{
    public class GetSummaryOfProductsQueryMappingTests
    {
        private readonly IMapper _mapper;
        private readonly IFixture _fixture;

        public GetSummaryOfProductsQueryMappingTests()
        {
            var config = new MapperConfiguration(configure => configure.AddMaps(typeof(GetSummaryOfProductsRequest), typeof(GetSummaryOfProductsQuery)));
            _mapper = config.CreateMapper();
            _fixture = new Fixture().Customize(new TestConventions());
        }

        [Fact]
        public void Profile_RequestMapsCorrectlyToCommand()
        {
            var request = _fixture.Build<GetSummaryOfProductsRequest>().Create();

            var query = _mapper.Map<GetSummaryOfProductsQuery>(request);

            query.PriceMin.ShouldBe(request.PriceMin);
            query.PriceMax.ShouldBe(request.PriceMax);
            query.IsFantastic.ShouldBe(request.IsFantastic);
            query.RatingMin.ShouldBe(request.RatingMin);
            query.RatingMax.ShouldBe(request.RatingMax);
        }
    }
}
