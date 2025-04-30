namespace InventoryAndAccountingServices.Contracts
{
    public class GetInventoryGroupsDto
    {
        public int GroupId { get; set; }
        public int? CompanyId { get; set; }
        public string? GroupName { get; set; }
        public string? Alias { get; set; }

        public string? ParentName { get; set; }
    }
}
