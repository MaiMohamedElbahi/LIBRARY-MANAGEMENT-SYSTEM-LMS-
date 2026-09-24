using AutoMapper;
using LIBRARY_MANAGEMENT_SYSTEM__LMS_.DTOs;
using LIBRARY_MANAGEMENT_SYSTEM__LMS_.DTOs.BookDTOs;
using LIBRARY_MANAGEMENT_SYSTEM__LMS_.DTOs.BorrowRecordDTOs;
using LIBRARY_MANAGEMENT_SYSTEM__LMS_.DTOs.BorrowRecordDTOS;
using LIBRARY_MANAGEMENT_SYSTEM__LMS_.DTOs.MemberDTOs;
using LIBRARY_MANAGEMENT_SYSTEM__LMS_.Models;

namespace LIBRARY_MANAGEMENT_SYSTEM__LMS_.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CreateUpdateCategoryDTO>().ReverseMap();
            CreateMap<Category, PartiallyUpdateCategoryDTO>().ReverseMap();

            CreateMap<Book, CreateUpdateBookDTO>().ReverseMap();
            CreateMap<Book, PartiallyUpdateBookDTO>().ReverseMap();

            CreateMap<BorrowRecord, CreateUpdateBorrowRecordDTO>().ReverseMap();
            CreateMap<BorrowRecord, PartiallyUpdateBorrowRecordDTO>().ReverseMap();

            CreateMap<Member, CreateUpdateMemberDTO>().ReverseMap();
            CreateMap<Member, PartiallyUpdateMemberDTO>().ReverseMap();
        }
    }
}
