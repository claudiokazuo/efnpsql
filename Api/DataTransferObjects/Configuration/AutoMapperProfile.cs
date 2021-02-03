using AutoMapper;
using Domain.Entities;

namespace Api.DataTransferObjects.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            //CreateMap<DocumentTypeDTO, DocumentType>();
            CreateMap<DocumentType, DocumentTypeDTO>();            
        }
    }
}
