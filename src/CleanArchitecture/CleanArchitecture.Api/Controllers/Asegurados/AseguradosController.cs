using CleanArchitecture.Application.Features.Asegurados.CrearAsegurado;
using CleanArchitecture.Application.Features.Asegurados.GetAsegurado;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers.Asegurados;

[ApiController]
[Route("api/asegurados")]
public class AseguradosController : ControllerBase
{
    private readonly ISender _sender;
    public AseguradosController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> searchAsegurados(CancellationToken cancellationToken)
    {
        var query = new GetAseguradQuery();
        var resultado = await _sender.Send(query, cancellationToken);
        return Ok(resultado.Value);
    }

    [HttpPost]
    public async Task<IActionResult> GuardarAsegurado(
        GuardarAseguradoRequest request,
        CancellationToken cancellationToken
    )
    {
        var command = new CrearAseguradoCommand(
            request.codigoParentesco,
            request.numeroContrato
        );

        var resultado = await _sender.Send(command, cancellationToken);
        if (resultado.IsFailure)
        {
            return BadRequest(resultado.Error);
        }

        return CreatedAtAction(
            nameof(GuardarAsegurado),
            new{id=resultado.Value},
            resultado.Value
        );
    }
}