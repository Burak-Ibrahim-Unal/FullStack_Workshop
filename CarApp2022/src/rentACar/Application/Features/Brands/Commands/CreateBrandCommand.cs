﻿using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Caching;
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
    public class CreateBrandCommand : IRequest<CreateBrandDto>, ILoggableRequest
    {
        public string Name { get; set; }


        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreateBrandDto>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;
            private readonly BrandBusinessRules _brandBusinessRules;
            private readonly ICacheService _cacheService;
            //private readonly IMailService _mailService;


            public CreateBrandCommandHandler(IBrandRepository brandRepository,
                IMapper mapper,
                BrandBusinessRules brandBusinessRules,
                ICacheService cacheService
                /*IMailService mailService*/)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
                _brandBusinessRules = brandBusinessRules;
                _cacheService= cacheService;
                //_mailService = mailService;
            }


            public async Task<CreateBrandDto> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                await _brandBusinessRules.CheckBrandByName(request.Name);

                Brand mappedBrand = _mapper.Map<Brand>(request);

                Brand createdBrand = await _brandRepository.AddAsync(mappedBrand);

                _cacheService.Remove("brands-list");

                #region send mail 
                //var mail = new Mail
                //{
                //    Subject = "Bootcamp - Add New Brand",
                //    ToFullName = "Burak İbrahim Ünal",
                //    ToEmail = "burakibrahim@gmail.com",
                //    HtmlBody = "aaaaaaaaaaaaaaaaaaaaaaaaaaa bbbbbbbbbbbbbbbbbbbbbbbbb"

                //};
                //_mailService.SendEmail(mail); 
                #endregion

                CreateBrandDto brandDtoToReturn = _mapper.Map<CreateBrandDto>(createdBrand);

                return brandDtoToReturn;
            }

        }

    }
}
