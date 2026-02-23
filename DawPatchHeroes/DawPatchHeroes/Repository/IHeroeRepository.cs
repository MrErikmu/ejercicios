using DawPatchHeroes.Models;

namespace DawPatchHeroes.Repository;

public interface IHeroeRepository
{
    public void GetAllHeroes();
    public Dictionary<string,Mission>? GetAllMissions();
    public List<Mission>? GetMissionsOrderBy(TypeOrder type);
    public void AddHeroe(Heroe heroe);
    public void AddMission(Mission mission);
    public List<Heroe>? GetHeroesOrderBy(TypeOrder type);
}