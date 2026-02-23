using DawPatchHeroes.Models;
namespace DawPatchHeroes.Repository;
using static System.Console;
public class HeroeRepository: IHeroeRepository
{
    private static HeroeRepository? _instance;
    private readonly List<Heroe>? _heroes = Factory.Factory.SeedHeroes();
    private readonly List<Mission>? _missions = Factory.Factory.SeedMission();
    public void GetAllHeroes()
    {
        if (_heroes!.Any())
        {
            _heroes!.ForEach(WriteLine);
        }
        else WriteLine("Apologies, no heroes are currently available.");
    }
/// <summary>
/// Obtiene todas las misiones organizadas en un mapa para un acceso eficiente
/// </summary>
/// <remarks>
/// Metodo auxiliar utilizado por el servicio
/// </remarks>
/// <returns> Un mapa con clave nombre de mision y valor objeto mision</returns>
    public Dictionary<string, Mission>? GetAllMissions()
    {
        if (_missions != null) return _missions.ToDictionary(m => m.Name, m => m);
        return null;
    }

    public List<Heroe>? GetHeroesOrderBy(TypeOrder type)
    {
        if (_heroes.Any())
        {
            switch (type)
            {
                case TypeOrder.Heroebyname: return _heroes.OrderBy(h1 => h1.Name).ToList();
                case TypeOrder.Heroebyminlvl: return _heroes.OrderBy(h1 => h1.Lvl).ToList();
                case TypeOrder.Heroebyexp: return _heroes.OrderBy(h1 => h1.Exp).ToList();
                case TypeOrder.Heroebypowerlvl: return _heroes.OrderBy(h1 => h1.PowerLvl).ToList();
            }
        }
        return null;
    }
    public List<Mission>? GetMissionsOrderBy(TypeOrder type)
    {
        if (_missions.Any())
        {
            switch (type)
            {
                case TypeOrder.Missionpending: return _missions
                    .Where(m => m.Status == MisionStatus.Ongoing)
                    .ToList();
                case TypeOrder.Missionbycollabrequired: return _missions
                    .Where(m => m.CollabRequited)
                    .ToList();
            } 
        }
        return null;
    }
    /// <summary>
    /// Funcion para añadir heroes 
    /// </summary>
    /// <param name="heroe"> Objeto heroe previamente validado por la clase validador </param>
    public void AddHeroe(Heroe heroe)
    {
        _heroes!.Add(heroe);
        WriteLine("Heroe successfully registered");
    }
    /// <summary>
    /// Funcion para añadir misiones 
    /// </summary>
    /// <param name="mission"> objeto mision previamente validado por la clase validator</param>
    public void AddMission(Mission mission )
    {
        _missions!.Add(mission);
        WriteLine("Mission successfully registered");
    }

    public static HeroeRepository GetInstance()
    {
        return _instance ??= new HeroeRepository(); 
    }
}