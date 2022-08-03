using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Features.UserFeatures.Commands.CheckUser
{
    public class CheckUserCommandRequest: IRequest<CheckUserCommandResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
