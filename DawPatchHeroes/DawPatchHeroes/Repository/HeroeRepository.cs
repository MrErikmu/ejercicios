using DawPatchHeroes.Models;
namespace DawPatchHeroes.Repository;
using Serilog;
using static System.Console;
public class HeroeRepository: IHeroeRepository
{
   // private readonly ILogger _logger;
    private static HeroeRepository? _instance;
    private readonly List<Heroe>? _heroes = Factory.Factory.SeedHeroes();
    private readonly List<Mission>? _missions = Factory.Factory.SeedMission();
    public List<Heroe> GetAllHeroes()
    {
        return _heroes ?? new List<Heroe>();
    }
    
/// <summary>
/// Obtiene todas las misiones organizadas en un mapa para un acceso eficiente
/// </summary>
/// <remarks>
/// Metodo auxiliar utilizado por el servicio
/// </remarks>
/// <returns> Un mapa con clave nombre de mision y valor objeto mision</returns>
    public List<Mission> GetAllMissions()
    {
        return _missions ?? new List<Mission>();
    }

    public List<Heroe>? GetHeroesOrderBy(TypeOrder type)
    {
        if (_heroes.Any())
        {
            switch (type)
            {
                case TypeOrder.Heroebyname: return _heroes.OrderBy(h1 => h1.Name).ToList();
                case TypeOrder.Heroebyminlvl: return _heroes.OrderByDescending(h1 => h1.Lvl).ToList();
                case TypeOrder.Heroebyexp: return _heroes.OrderByDescending(h1 => h1.Exp).ToList();
                case TypeOrder.Heroebypowerlvl: return _heroes.OrderByDescending(h1 => h1.PowerLvl).ToList();
            }
        }
        return null;
    }
    public List<Mission>? GetMissionsOrderBy(TypeOrder type)
    {
        //_logger.Debug("Requesting missions ordered by {Type}", type);
        return type switch
        {
            TypeOrder.Missionpending => _missions
                .Where(m => m.Status == MisionStatus.Ongoing)
                .ToList(),
            TypeOrder.Missionbycollabrequired => _missions
                .Where(m => m.CollabRequired)
                .ToList(),
            _=> []
        };
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

    public void AddHeroeToMission(Heroe heroe, Mission mission)
    {
        foreach (var m in _missions)
        {
            if (m.Name == mission.Name && m.Status!=MisionStatus.Complete)
            {
                m.Team.Add(heroe);
                WriteLine($"Heroe: {heroe.Name} successfully registered for Mission: {mission.Name}");
            }
        }
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