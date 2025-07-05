using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Vehiculos;
using Microsoft.IdentityModel.Tokens;

namespace CleanArchitecture.Domain.Alquileres;

public sealed class Alquiler : Entity
{
    private Alquiler()
    {

    }
    private Alquiler(
        Guid id,
        Guid vehiculoId,
        Guid userId
       /* Moneda precioPorPeriodo,
        Moneda mantenimiento,
        Moneda accesorios,
        Moneda precioTotal*/
    ) : base(id)
    {
        VehiculoId = vehiculoId;
        UserId = userId;
        /*PrecioTotal = precioTotal;
        PrecioPorPeriodo = precioPorPeriodo;
        Mantenimiento = mantenimiento;
        Accesorios = accesorios;*/
    }
    public Guid VehiculoId { get; set; }
    public Guid UserId { get; private set; }
    /*public Moneda? PrecioPorPeriodo { get; private set; }
    public Moneda? Mantenimiento { get; private set; }
    public Moneda? Accesorios { get; private set; }
    public Moneda? PrecioTotal { get; private set; }*/

    public static Alquiler Reservar(
        Vehiculo vehiculo,
        Guid userId
    )
    {
        var alquiler = new Alquiler(
            Guid.NewGuid(),
            vehiculo.Id,
            userId
        );
        return alquiler;
    }
    
}