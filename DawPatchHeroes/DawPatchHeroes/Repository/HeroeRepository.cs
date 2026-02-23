using DawPatchHeroes.Models;
using System.Linq;
namespace DawPatchHeroes.Repository;

public class HeroeRepository: IHeroeRepository
{
    private List<Heroe>? _heroes;
    private List<Mission>? _missions;
    public Heroe GetHeroeByName(string name)
    {
        var heroe = _heroes
            .Where(h1 => h1.Name == name)
            .Single();
        return heroe;
    }

    public Heroe GetHeroeByLvl(int lvl)
    {
        var heroe = _heroes
            .Where(h1 => h1.Lvl == lvl)
            .Single();
        return heroe;
    }

    public List<Mission> GetPendingMissions()
    {
        var PendingM = _missions
            .Where(m => m.Status == MisionStatus.Ongoing)
            .ToList();
        return PendingM;
    }

    public List<Heroe> GetHeroesOrderByLvl()
    {
        var heroelist = _heroes
            .OrderBy(h1 => h1.Lvl)
            .ToList();
        return heroelist;
    }

    public List<Heroe> GetHeroeOrderByExp()
    {
        var heroelist = _heroes
            .OrderBy(h1 => h1.Exp)
            .ToList();
        return heroelist;
    }

    public List<Heroe> GetHeroeOrderByPower()
    {
        var heroelist = _heroes
            .OrderBy(h1 => h1.PowerLvl)
            .ToList();
        return heroelist;
    }
}