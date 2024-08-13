using AutoMapper;
using MediatR;
using MongoDB.Driver;
using WinningGroup.Core.Filters;
using WinningGroup.Infrastructure.Repositories;

namespace WinningGroup.Core.Activity.Queries
{
    public class GetSummaryOfProductsQueryHandler : IRequestHandler<GetSummaryOfProductsQuery, GetSummaryOfProductsViewModel>
    {
        private IMapper _mapper;
        private IProductsRepository _productsRepository;

        public GetSummaryOfProductsQueryHandler(IMapper mapper, IProductsRepository productsRepository)
        {
            _mapper = mapper;
            _productsRepository = productsRepository;
        }

        public async Task<GetSummaryOfProductsViewModel> Handle(GetSummaryOfProductsQuery request, CancellationToken cancellationToken)
        {
            var filter = ProductFilter.GetFilter(request);
            var productsCollection = await _productsRepository.GetProducts(filter);

            var viewModel = new GetSummaryOfProductsViewModel();
            viewModel.ProductCollection = _mapper.Map<List<ProductDto>>(productsCollection).ToList();
            
            return viewModel;
        }
    }
}
