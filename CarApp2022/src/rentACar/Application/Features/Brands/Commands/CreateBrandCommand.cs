using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Mailing;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands
{
    public class CreateBrandCommand : IRequest<BrandCreateDto>
    {
        public string Name { get; set; }


        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, BrandCreateDto>
        {
           private readonly IBrandRepository _brandRepository;
           private readonly IMapper _mapper;
           private readonly BrandBusinessRules _brandBusinessRules;
           private readonly IMailService _mailService;

            public CreateBrandCommandHandler(IBrandRepository brandRepository,
                IMapper mapper,
                BrandBusinessRules brandBusinessRules,
                IMailService mailService)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
                _brandBusinessRules = brandBusinessRules;
                _mailService = mailService;
            }

            public async Task<BrandCreateDto> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                await _brandBusinessRules.BrandNameCanNotBeDuplicatedWhenInserted(request.Name);
                var mappedBrand = _mapper.Map<Brand>(request);

                var createdBrand = await _brandRepository.AddAsync(mappedBrand);

                var mail = new Mail
                {
                    Subject = "Bootcamp - Add New Brand",
                    ToFullName = "Burak İbrahim Ünal",
                    ToEmail="burakibrahim@gmail.com",
                    HtmlBody="aaaaaaaaaaaaaaaaaaaaaaaaaaa bbbbbbbbbbbbbbbbbbbbbbbbb"

                };
                _mailService.SendEmail(mail);

                var brandDtoToReturn = _mapper.Map<BrandCreateDto>(createdBrand);
                return brandDtoToReturn;
            }

        }

    }
}
