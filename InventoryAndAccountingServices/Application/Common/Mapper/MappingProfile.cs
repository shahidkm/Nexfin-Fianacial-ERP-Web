using AutoMapper;
using InventoryAndAccountingServices.Application.Features.Commands;
using InventoryAndAccountingServices.Application.Features.Commands.Inventory_Masters;
using InventoryAndAccountingServices.Application.Features.Queries;
using InventoryAndAccountingServices.Domain.Entities;

namespace InventoryAndAccountingServices.Application.Common.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<InventoryGroupCommand,InventoryGroup>();
            CreateMap<InventoryLedgerCommand, InventoryLedger>();
            CreateMap<GetInventoryGroupQuery, InventoryGroup>();
            CreateMap<StockGroupCommand, StockGroup>();
            CreateMap<StockCategoryCommand, StockCategory>();
            CreateMap<GodownCommand, Godown>();
            CreateMap<StockItemCommand, StockItem>();
            CreateMap<UnitOfMeasureCommand,UnitOfMeasure>();

        }
    }
}
