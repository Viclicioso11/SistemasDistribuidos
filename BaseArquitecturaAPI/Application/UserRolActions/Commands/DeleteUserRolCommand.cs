using MediatR;

namespace Application.UserRolActions.Commands
{
    public class DeleteUserRolCommand : IRequest<bool>
    {
        public int UserId  { get; set; }

        public int RolId { get; set; }

    }
}
