using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Vehiculos;

public sealed class Vehiculo : Entity
{
    private Vehiculo()
    {

    }
    public Vehiculo(
        Guid id,
        Modelo modelo,
        Vin vin
        /*Moneda precio,
        Moneda mantenimineto,
        DateTime? fechaUltimoAlquiler,
        List<Accesorio> accesorios,
        Direccion? direccion*/
        ) : base(id)
    {
        Modelo = modelo;
        Vin = vin;
        /*Precio = precio;
        Mantenimiento = mantenimineto;
        FechaUltimoAlquiler = fechaUltimoAlquiler;
        Accesorios = accesorios;
        Direccion = direccion;*/
    }
    public Modelo? Modelo { get; private set; }
    public Vin? Vin { get; private set; }
    //public Direccion? Direccion { get; private set; }
    /*public Moneda? Precio { get; private set; }
    public Moneda? Mantenimiento { get; private set; }*/
    //public DateTime? FechaUltimoAlquiler { get; private set; }
    //public List<Accesorio> Accesorios { get; private set; } = new();

    public static Vehiculo Guardar(
        Modelo modelo,
        Vin vin
    )
    {
        var vehiculo = new Vehiculo(
            Guid.NewGuid(),
            modelo,
            vin
        );
        return vehiculo;
    }
}