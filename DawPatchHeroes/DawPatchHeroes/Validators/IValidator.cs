using DawPatchHeroes.Models;

namespace DawPatchHeroes.Validators;

public interface IValidator
{
    public Heroe ValidateHeroe(Heroe heroe);
    public Mission ValidateMission(Mission mission);
}