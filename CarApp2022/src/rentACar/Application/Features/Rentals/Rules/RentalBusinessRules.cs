using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Utilities;
using Domain.Entities;

namespace Application.Features.Rentals.Rules;

public class RentalBusinessRules
{
    private readonly IRentalRepository _rentalRepository;

    public RentalBusinessRules(IRentalRepository rentalRepository, ICarRepository carRepository)
    {
        _rentalRepository = rentalRepository;
    }

    public async Task RentalIdShouldExistWhenSelected(int id)
    {
        var result = await _rentalRepository.GetAsync(b => b.Id == id);
        if (result == null) throw new BusinessException("Rental not exists.");
    }

    public async Task RentalCanNotBeCreateWhenCarIsRented(int carId, DateTime rentalStartDate, DateTime rentalEndDate)
    {
        IPaginate<Rental> rentals = await _rentalRepository.GetListAsync(
                                        r => r.CarId == carId &&
                                             r.RentalEndDate >= rentalStartDate &&
                                             r.RentalStartDate <= rentalEndDate);

        if (rentals.Items.Any()) throw new BusinessException(Messages.CarCanNotBeRentedWhenAlreadyRented);
    }

    public async Task RentalCanNotBeUpdateWhenThereIsARentedCarInDate(int id, int carId, DateTime rentalStartDate,
                                                                      DateTime rentalEndDate)
    {
        IPaginate<Rental> rentals = await _rentalRepository.GetListAsync(
                                        r => r.Id != id && r.CarId == carId &&
                                             r.RentalEndDate >= rentalStartDate &&
                                             r.RentalStartDate <= rentalEndDate);
        if (rentals.Items.Any())
            throw new BusinessException("Rental can't be updated when there is another rented car for the date.");
    }

    public Task CompareCustomerFindeksScoreWithCarMinFindeksScore(
        short customerFindeksCreditRate, short carMinFindeksCreditRate)
    {
        if (customerFindeksCreditRate < carMinFindeksCreditRate)
            throw new BusinessException(
                "Rental can not be created when customer findeks credit score lower than car min findeks score.");
        return Task.CompletedTask;
    }
}