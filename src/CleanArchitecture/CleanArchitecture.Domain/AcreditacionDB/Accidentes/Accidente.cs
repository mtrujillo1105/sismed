using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.AcreditacionDB.Accidentes;

public sealed class Accidente : Entity
{
    public Guid IdAsegurado { get; private set; } // Corregido: IdAfiliado
    public string? Descripcion { get; private set; }
    public string? CodIpress { get; private set; }

    public Guid IdEstado{ get; private set; }
    public Guid IdPrestadorSalud { get; private set; } // Corregido: IdClinica
    public Guid IdAccidenteTipo { get; private set; } // Corregido: IdTipoAccidente
    public DateTime FechaAccidente { get; private set; }
    public Guid IdUsuarioRegistro { get; private set; }
    public Guid? IdUsuarioActualiza { get; private set; }
    public DateTime FechaCreacion { get; private set; }
    public DateTime? FechaActualizacion { get; private set; }

    private Accidente() { }
    private Accidente(
        Guid id,
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
            Guid.NewGuid(),
            idAsegurado,
            descripcion,
            codIpress
        );
        return accidente;
    }
}