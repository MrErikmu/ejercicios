using DawPatchHeroes.Models;

namespace DawPatchHeroes.Repository;

public interface IHeroeRepository
{
    public List<Heroe> GetAllHeroes();
    
    public List<Mission> GetAllMissions();
    public List<Mission>? GetMissionsOrderBy(TypeOrder type);
    public void AddHeroe(Heroe heroe);
    public void AddHeroeToMission(Heroe heroe, Mission mission);
    public void AddMission(Mission mission);
    public List<Heroe>? GetHeroesOrderBy(TypeOrder type);
}