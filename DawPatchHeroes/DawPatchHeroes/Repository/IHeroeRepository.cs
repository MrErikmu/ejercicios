using DawPatchHeroes.Models;

namespace DawPatchHeroes.Repository;

public interface IHeroeRepository
{
    public void GetAllHeroes();
    public Heroe GetHeroeByName(string name);
    public Heroe GetHeroeByLvl(int lvl);
    public List<Mission> GetPendingMissions();
    public List<Heroe>GetHeroesOrderByLvl();
    public List<Heroe> GetHeroeOrderByExp();
    public List<Heroe> GetHeroeOrderByPower();
    public void AddHeroe(Heroe heroe);
    public void AddMission(Mission mission);
}