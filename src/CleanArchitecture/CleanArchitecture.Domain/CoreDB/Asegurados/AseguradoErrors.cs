using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.CoreDB.Asegurados;

public static class AseguradoErrors
{
    public static Error NotFound = new(
        "Asegurado.Found",
        "No existe un asegurado con este id"
    );
    public static Error Overlap = new Error(
        "Asegurado.Overlap",
        "El Asegurado esta fallado"
    );
}