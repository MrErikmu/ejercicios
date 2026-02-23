using DawPatchHeroes.Models;
namespace DawPatchHeroes.Repository;
using static System.Console;
public class HeroeRepository: IHeroeRepository
{
    private static HeroeRepository? _instance; 
    private readonly List<Heroe>? _heroes = new ();
    private readonly List<Mission>? _missions = new();
    public void GetAllHeroes()
    {
       _heroes.ForEach(WriteLine);
    }

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
            .ThenBy(h1=> h1.Name)
            .ToList();
        return heroelist;
    }

    public List<Heroe> GetHeroeOrderByPower()
    {
        var heroelist = _heroes
            .OrderBy(h1 => h1.PowerLvl)
            .ThenBy(h1=> h1.Name)
            .ToList();
        return heroelist;
    }

    public void AddHeroe(Heroe heroe)
    {
        _heroes!.Add(heroe);
    }

    public void AddMission(Mission mission )
    {
        _missions!.Add(mission);
    }

    public static HeroeRepository GetInstance()
    {
        return _instance ??= new HeroeRepository(); 
    }
}