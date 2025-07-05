using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.CoreDB.Asegurados;

public sealed class Asegurado : Entity
{
    public Asegurado(
        Guid id,
        string codigoParentesco,
        string numeroContrato
        ) : base(id)
    {
        CodigoParentesco = codigoParentesco;
        NumeroContrato = numeroContrato;
    }
    public string CodigoParentesco { get; private set; }
    public string NumeroContrato { get; private set; }

    // Metodos
    public static Asegurado Create(
        string codigoParentesco,
        string numeroContrato
    )
    {
        var asegurado = new Asegurado(
            Guid.NewGuid(),
            codigoParentesco,
            numeroContrato
        );
        return asegurado;
    }
}