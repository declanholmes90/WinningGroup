using AutoFixture;
using AutoMapper;
using Shouldly;
using WinningGroup.Core.Activity.Queries;
using WinningGroup.Infrastructure.Entities;

namespace WinningGroup.UnitTests.MappingTests
{
    public class ProductMappingTests
    {
        private readonly IMapper _mapper;
        private readonly IFixture _fixture;

        public ProductMappingTests()
        {
            var config = new MapperConfiguration(configure => configure.AddMaps(typeof(Product), typeof(ProductDto)));
            _mapper = config.CreateMapper();
            _fixture = new Fixture().Customize(new TestConventions());
        }

        [Fact]
        public void Profile_EntityMapsCorrectlyToDto()
        {
            var entity = _fixture.Build<Product>().Create();

            var dto = _mapper.Map<ProductDto>(entity);

            dto.Id.ShouldBe(entity.Id);
            dto.Name.ShouldBe(entity.Name);
            dto.Sku.ShouldBe(entity.Sku);
            dto.Price.ShouldBe(entity.Price);
            dto.Attribute.Fantastic.Value.ShouldBe(entity.Attribute.Fantastic.Value);
            dto.Attribute.Fantastic.Type.ShouldBe(entity.Attribute.Fantastic.Type);
            dto.Attribute.Fantastic.Name.ShouldBe(entity.Attribute.Fantastic.Name);
            dto.Attribute.Rating.Name.ShouldBe(entity.Attribute.Rating.Name);
            dto.Attribute.Rating.Value.ShouldBe(entity.Attribute.Rating.Value);
            dto.Attribute.Rating.Type.ShouldBe(entity.Attribute.Rating.Type);
        }
    }
}