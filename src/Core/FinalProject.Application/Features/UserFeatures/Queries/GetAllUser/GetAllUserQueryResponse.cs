using FinalProject.Application.DTOs.User;
using FinalProject.Application.Models.Paging;

namespace FinalProject.Application.Features.UserFeatures.Queries.GetAllUser
{
    public class GetAllUserQueryResponse
    {
        public List<GetUserDto> Users { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
