using AutoMapper;
using InventoryAndAccountingServices.Application.Features.Commands;
using InventoryAndAccountingServices.Application.Interfaces;
using InventoryAndAccountingServices.Contracts;
using InventoryAndAccountingServices.Domain.Entities;
using MediatR;

namespace InventoryAndAccountingServices.Application.Features.Queries
{
 
    public class GetInventoryGroupHandler : IRequestHandler<GetInventoryGroupQuery, List<GetInventoryGroupsDto>>
    {

        private readonly IAccountingMastersRepositories _repository;
        private readonly IMapper _mapper;
        public GetInventoryGroupHandler(IAccountingMastersRepositories accountingMastersRepository, IMapper mapper)
        {
            _repository = accountingMastersRepository;
            _mapper = mapper;
        }

        public async Task<List<GetInventoryGroupsDto>> Handle(GetInventoryGroupQuery query, CancellationToken cancellationToken)
        {
           


            var response = await _repository.GetInventoryGroup(query.CompanyId);

            return response;
        }
    }
}
