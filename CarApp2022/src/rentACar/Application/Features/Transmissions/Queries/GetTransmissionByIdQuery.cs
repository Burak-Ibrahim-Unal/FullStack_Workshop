using Application.Features.Transmissions.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Transmissions.Queries.GetByIdTransmission;

public class GetTransmissionByIdQuery : IRequest<Transmission>
{
    public int Id { get; set; }

    public class GetTransmissionByIdResponseHandler : IRequestHandler<GetTransmissionByIdQuery, Transmission>
    {
        private readonly ITransmissionRepository _transmissionRepository;
        private readonly TransmissionBusinessRules _transmissionBusinessRules;

        public GetTransmissionByIdResponseHandler(ITransmissionRepository transmissionRepository, TransmissionBusinessRules transmissionBusinessRules)
        {
            _transmissionRepository = transmissionRepository;
            _transmissionBusinessRules = transmissionBusinessRules;
        }


        public async Task<Transmission> Handle(GetTransmissionByIdQuery request, CancellationToken cancellationToken)
        {
            await _transmissionBusinessRules.TransmissionCanNotBeEmptyWhenSelected(request.Id);

            Transmission? Transmission = await _transmissionRepository.GetAsync(b => b.Id == request.Id);
            return Transmission;
        }

    }
}