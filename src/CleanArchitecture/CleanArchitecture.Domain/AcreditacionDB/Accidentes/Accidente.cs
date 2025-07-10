using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.AcreditacionDB.Accidentes;

public sealed class Accidente : Entity<AccidenteId>
{
    public Guid IdAsegurado { get; private set; } // Corregido: IdAfiliado
    public string? Descripcion { get; private set; }
    public string? CodIpress { get; private set; }

    private Accidente() { }
    private Accidente(
        AccidenteId id,
        Guid idAsegurado,
        string descripcion,
        string codIpress
    ) : base(id)
    {
        IdAsegurado = idAsegurado;
        Descripcion = descripcion;
        CodIpress = codIpress;
    }

    // Metodos
    public static Accidente Create(
        Guid idAsegurado,
        string descripcion,
        string codIpress
    )
    {
        var accidente = new Accidente(
            AccidenteId.New(),
            idAsegurado,
            descripcion,
            codIpress
        );
        return accidente;
    }
}