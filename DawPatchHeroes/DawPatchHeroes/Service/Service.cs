using DawPatchHeroes.Factory;
using DawPatchHeroes.Models;
using DawPatchHeroes.Repository;
namespace DawPatchHeroes.Service;

public class Service(IFactory Factory, IHeroeRepository HeroeRepository):IService
{
    private List<Heroe> _heroes = Factory.SeedHeroes();
    private List<Mission> _missions = Factory.SeedMission();
    
}