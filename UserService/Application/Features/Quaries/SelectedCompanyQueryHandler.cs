using AutoMapper;
using MediatR;
using UserService.Application.Interfaces;

namespace UserService.Application.Features.Quaries
{
    public class GetSelectedCompanyHandler : IRequestHandler<GetSelectCompany, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetSelectedCompanyHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(GetSelectCompany request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.VerifyUserById(request.UserId.ToString());
          
            var response = await _userRepository.AddCompany(user, request.CompanyId);
            return response;
        }
    }
}
