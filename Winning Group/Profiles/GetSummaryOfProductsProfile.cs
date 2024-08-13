using AutoMapper;
using WinningGroup.Core.Activity.Queries;
using WinningGroupAPI.Requests;

namespace WinningGroupAPI.Profiles
{
    public class GetSummaryOfProductsProfile : Profile
    {
        public GetSummaryOfProductsProfile() 
        {
            CreateMap<GetSummaryOfProductsRequest, GetSummaryOfProductsQuery>();
        }
    }
}
