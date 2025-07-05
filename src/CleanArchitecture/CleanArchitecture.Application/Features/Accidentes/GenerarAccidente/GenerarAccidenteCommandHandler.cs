using System.Windows.Input;
using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.AcreditacionDB.Accidentes;
using CleanArchitecture.Domain.CoreDB.Asegurados;

namespace CleanArchitecture.Application.Features.Accidentes.GenerarAccidente;

internal sealed class GenerarAccidenteCommandHandler :
ICommandHandler<GenerarAccidenteCommand, Guid>
{
    private readonly IAccidenteRepository _accidenteRepository;
    private readonly IAseguradoRepository _aseguradoRepository;
    private readonly IAcreditacionUnitOfWork _unitOfWork;
    public GenerarAccidenteCommandHandler(
        IAccidenteRepository accidenteRepository,
        IAseguradoRepository aseguradoRepository,        
        IAcreditacionUnitOfWork unitOfWork
    )
    {
        _accidenteRepository = accidenteRepository;
        _aseguradoRepository = aseguradoRepository;        
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<Guid>> Handle(
        GenerarAccidenteCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var asegurado = await _aseguradoRepository.GetByIdAsync(request.IdAsegurado, cancellationToken);
            if (asegurado is null)
            {
                return Result.Failure<Guid>(AseguradoErrors.NotFound);
            }

            // Guardamos 
            var accidente = Accidente.Create(
                request.IdAsegurado,
                request.Descripcion,
                request.CodIpress
            );
            _accidenteRepository.Add(accidente);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return accidente.Id;
        }
        catch (ConcurrencyException)
        {
            return Result.Failure<Guid>(AccidenteError.NotFound);
        }
    }
}