using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.UserRolActions.Dtos
{
    public class UserRolDto : IMapFrom<RolOption>
    {
        public int Id { get; set; }

        public int RolId { get; set; }

        public int OptionId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserRol, UserRolDto>();
        }
    }
}
