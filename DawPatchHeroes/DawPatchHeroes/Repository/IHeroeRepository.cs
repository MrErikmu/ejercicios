using DawPatchHeroes.Models;

namespace DawPatchHeroes.Repository;

public interface IHeroeRepository
{
    public Heroe GetHeroeByName();
    public Heroe GetHeroeByLvl(int lvl);
    public List<Mission> GetPendingMissions();
    public List<Heroe>GetHeroesOrderByLvl();
    public List<Heroe> GetHeroeOrderByExp();
    public List<Heroe> GetHeroeOrderByPower();
}