using FinalProject.Application.DTOs.User;
using FinalProject.Application.Models.Paging;
using FinalProject.Domain.Entities.Identity;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Features.UserFeatures.Queries.GetAllUser
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQueryRequest, GetAllUserQueryResponse>
    {
        private readonly UserManager<AppUser> _userManager;

        public GetAllUserQueryHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<GetAllUserQueryResponse> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
        {

            IQueryable<AppUser> Lists = _userManager.Users;
            
            if (!string.IsNullOrWhiteSpace(request.SearchByUserName))
            {
                Lists = Lists.Where(x => x.UserName.Contains(request.SearchByUserName));
            }

            if (request.RegistrationRangeCeiling.HasValue || request.RegistrationRangeLower.HasValue)
            {
                Lists = Lists.Where(x => x.RegistrationDate <= request.RegistrationRangeCeiling && x.RegistrationDate >= request.RegistrationRangeLower);
            }


            int TotalUser = Lists.Count();
            int TotalPage = (int)Math.Ceiling(TotalUser / (double)request.Limit);
            int Skip = (request.Page - 1) * request.Limit;

            PagingInfo PageInfo = new()
            {
                TotalData = TotalUser,
                TotalPage = TotalPage,
                PageLimit = request.Limit,
                PageNum = request.Page,
                HasNext = request.Page >= TotalPage ? false : true,
                HasPrevious = request.Page == 1 ? false : true,
            };
            List<AppUser> UserList = Lists.Skip(Skip).Take(request.Limit).ToList();
            List<GetUserDto> UserDtoList = UserList.Adapt<List<GetUserDto>>();
            return new GetAllUserQueryResponse()
            {
                PagingInfo = PageInfo,
                Users = UserDtoList
            };
        }
    }
}
