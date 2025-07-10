using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.CoreDB.Asegurados;

public sealed class Asegurado : Entity<AseguradoId>
{
    public string CodigoParentesco { get; private set; }
    public string NumeroContrato { get; private set; }
    public Asegurado(
        AseguradoId id,
        string codigoParentesco,
        string numeroContrato
        ) : base(id)
    {
        CodigoParentesco = codigoParentesco;
        NumeroContrato = numeroContrato;
    }


    // Metodos
    public static Asegurado Create(
        string codigoParentesco,
        string numeroContrato
    )
    {
        var asegurado = new Asegurado(
            AseguradoId.New(),
            codigoParentesco,
            numeroContrato
        );
        return asegurado;
    }
}