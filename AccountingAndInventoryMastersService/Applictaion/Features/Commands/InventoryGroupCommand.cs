using MediatR;
namespace AccountingAndInventoryMastersService.Applictaion.Features.Commands
{

    public record InventoryGroupCommand(int CompanyId, string GroupName, string? Alias, int? ParentGroupId) : IRequest<string>;

}
