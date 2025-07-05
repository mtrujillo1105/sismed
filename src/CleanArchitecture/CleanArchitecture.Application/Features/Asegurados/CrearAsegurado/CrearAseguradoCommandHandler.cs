using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.CoreDB.Asegurados;

namespace CleanArchitecture.Application.Features.Asegurados.CrearAsegurado;

internal sealed class CrearAseguradoCommandHandler :
ICommandHandler<CrearAseguradoCommand, Guid>
{
    private readonly IAseguradoRepository _aseguradoRepository;
    private readonly ICoreUnitOfWork _unitOfWork;
    public CrearAseguradoCommandHandler(
        IAseguradoRepository aseguradoRepository,
        ICoreUnitOfWork unitOfWork
    )
    {
        _aseguradoRepository = aseguradoRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<Guid>> Handle(
        CrearAseguradoCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var asegurado = Asegurado.Create(
                request.codigoParentesco,
                request.numeroContrato
            );
            _aseguradoRepository.Add(asegurado);
            
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return asegurado.Id;
        }
        catch (ConcurrencyException)
        {
            return Result.Failure<Guid>(AseguradoErrors.Overlap);
        }
    }
}