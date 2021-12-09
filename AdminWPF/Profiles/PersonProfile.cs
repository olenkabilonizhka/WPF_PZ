using AutoMapper;
using DTO;
using System.Text;

namespace AdminWPF
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonDTO, PersonValid>()
                .ForMember(x => x.Password, s => s.MapFrom(x => Encoding.UTF8.GetString(x.Password)));
            CreateMap<PersonValid, PersonDTO>()
                .ForMember(x => x.Password, s => s.MapFrom(x => Encoding.UTF8.GetBytes(x.Password)));
        }
    }
}
