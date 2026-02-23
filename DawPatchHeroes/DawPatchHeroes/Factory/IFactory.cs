using DawPatchHeroes.Models;

namespace DawPatchHeroes.Factory;

public interface IFactory
{
    public  List<Heroe> SeedHeroes();
    public  List<Mission>  SeedMission();
}