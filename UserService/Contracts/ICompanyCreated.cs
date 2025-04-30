namespace UserService.Contracts
{
    public interface ICompanyCreated
    {
        Guid CompanyId { get; }
        Guid CreatedByUserId { get; }
        string CompanyName { get; }
    }
}
