using AccountingAndInventoryMastersService.Applictaion.Features.Commands;
using AccountingAndInventoryMastersService.Domain.Entities;
using AutoMapper;

namespace AccountingAndInventoryMastersService.Applictaion.Common.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<InventoryGroupCommand, InventoryGroup>();
            CreateMap<InventoryLedgerCommand, InventoryLedger>();

        }
    }
}
