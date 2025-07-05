using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.AcreditacionDB.Accidentes;
public static class AccidenteError
{
    public static Error NotFound = new(
        "Accidente.NotFound",
        "El Accidente no existe."
    );
}