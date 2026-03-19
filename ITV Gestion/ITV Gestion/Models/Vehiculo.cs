namespace ITV_Gestion.Models;

public record Vehiculo
{
    public string Matricula { get; init; }
    public string Marca { get; init; }
    public string Modelo { get; init; }
    public int Cilindrada { get; init;}
    public TipoMotor Motor { get; init; }
}