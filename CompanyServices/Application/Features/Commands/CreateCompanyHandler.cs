using AutoMapper;
using CompanyServices.Application.Interfaces;
using CompanyServices.Domain.Entities;
using CompanyServices.Infrastructure.Services;
using MediatR;

namespace CompanyServices.Application.Features.Commands
{
    public class CreateCompanyHandler : IRequestHandler<CreateCompanyCommand, string>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        private readonly CloudinaryService _cloudinary;
        public CreateCompanyHandler(ICompanyRepository companyRepository, IMapper mapper,CloudinaryService cloudinaryService)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
            _cloudinary = cloudinaryService;
        }

        public async Task<string> Handle(CreateCompanyCommand companyCommand, CancellationToken cancellationToken)
        {

            var image =  await _cloudinary.CompanyImage(companyCommand.CompanyImage);
            var company = _mapper.Map<Company>(companyCommand);
            company.Image = image;
            var response = await _companyRepository.CreateCompany(company);
            return response;
        }
    }
}
