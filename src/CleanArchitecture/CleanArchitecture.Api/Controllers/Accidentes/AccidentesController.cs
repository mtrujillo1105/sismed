using CleanArchitecture.Application.Features.Accidentes.GenerarAccidente;
using CleanArchitecture.Application.Features.Accidentes.GetAccidente;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers.Accidentes;

[ApiController]
[Route("api/accidentes")]
public class AccidentesController : ControllerBase
{
    private readonly ISender _sender;
    public AccidentesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> searchAccidentes(
        CancellationToken cancellationToken
    )
    {
        var query = new GetAccidenteQuery();
        var resultado = await _sender.Send(query, cancellationToken);
        return Ok(resultado.Value);
    }

    [HttpPost]
    public async Task<IActionResult> GuardarAccidente(
        GuardarAccidenteRequest request,
        CancellationToken cancellationToken
    )
    {
        var command = new GenerarAccidenteCommand(
            request.IdAsegurado,
            request.Descripcion,
            request.CodIpress
        );

        var resultado = await _sender.Send(command, cancellationToken);
        if (resultado.IsFailure)
        {
            return BadRequest(resultado.Error);
        }

        return CreatedAtAction(
            nameof(searchAccidentes),
            new{id=resultado.Value},
            resultado.Value
        );
    }
}