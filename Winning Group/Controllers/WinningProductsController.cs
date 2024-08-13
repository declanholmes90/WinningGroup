using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WinningGroupAPI.Requests;
using WinningGroup.Core.Activity.Queries;

namespace WinningGroupAPI.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class WinningProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public WinningProductsController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost(nameof(GetSummaryOfProducts))]
        public async Task<GetSummaryOfProductsViewModel> GetSummaryOfProducts(GetSummaryOfProductsRequest request, CancellationToken cancellationToken)
        {
            var query = _mapper.Map<GetSummaryOfProductsQuery>(request);
            var result = await _mediator.Send(query, cancellationToken);

            return result;
        }
    }
}
