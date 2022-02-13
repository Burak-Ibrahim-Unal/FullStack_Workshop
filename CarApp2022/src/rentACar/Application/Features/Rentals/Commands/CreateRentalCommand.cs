using Application.Features.Rentals.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Mailing;
using Domain.Entities;
using MediatR;

namespace Application.Features.Rentals.Commands;

public class CreateRentalCommand : IRequest<Rental>
{
    public int CarId { get; set; }
    public int CustomerId { get; set; }
    public int RentalStartOfficeId { get; set; }
    public DateTime RentalStartDate { get; set; }
    public int RentalStartKilometer { get; set; }



    public class CreateRentalCommandHandler : IRequestHandler<CreateRentalCommand, Rental>
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        private readonly RentalBusinessRules _rentalBusinessRules;
        //private readonly ICarService _carService;



        public CreateRentalCommandHandler(
            IRentalRepository rentalRepository,
            ICarRepository carRepository, 
            IMapper mapper,
            RentalBusinessRules rentalBusinessRules
            //ICarService carService,
        )
        {
            _rentalRepository = rentalRepository;
            _carRepository = carRepository;
            _mapper = mapper;
            _rentalBusinessRules = rentalBusinessRules;
        }

        public async Task<Rental> Handle(CreateRentalCommand request, CancellationToken cancellationToken)
        {
            //await _rentalBusinessRules.RentalCanNotBeCreateWhenCarIsRented(request.CarId, request.RentStartDate,
            //                                                               request.RentEndDate);
            var car = await _carRepository.GetAsync(c => c.Id == request.CarId);
            //await _rentalBusinessRules.CompareCustomerFindeksScoreWithCarMinFindeksScore(
            //    customerFindeksCreditRate!.Score, car!.MinFindeksCreditRate);

            Rental mappedRental = _mapper.Map<Rental>(request);
            Rental createdRental = await _rentalRepository.AddAsync(mappedRental);

            return createdRental;
        }
    }
}