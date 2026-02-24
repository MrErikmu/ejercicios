
using DawPatchHeroes.Models;
using DawPatchHeroes.Repository;
using DawPatchHeroes.Validators;
using static System.Console;
namespace DawPatchHeroes.Service;

public class Service(IHeroeRepository heroeRepository, IValidator validator):IService
{
    private List<Heroe> _heroes = heroeRepository.GetAllHeroes();
    private List<Mission> _missions = heroeRepository.GetAllMissions();
    
    public void ListAll()
    {
        var currentheroes= heroeRepository.GetAllHeroes();
        if (currentheroes.Any())
        {
            _heroes!.ForEach(WriteLine);
        }
        else WriteLine("Apologies, no heroes are currently available.");
    }

    public void ShowRanking()
    {
        heroeRepository.GetHeroesOrderBy(type: TypeOrder.Heroebypowerlvl);
    }

    public void SimulateMission(string missionname)
    {
        var mission = _missions.FirstOrDefault(m => m.Name.Equals(missionname, StringComparison.OrdinalIgnoreCase));
        if (mission==null)
        {
            WriteLine($"Mission with name: {missionname} doesnt exist ");
        }
        else
        {
            mission.SumulateMission();
        }
    }

    public void GetHeroeByOrder(TypeOrder type)
    {
        var heroelist = heroeRepository.GetHeroesOrderBy(type);
        if (heroelist == null)
        {
            Console.WriteLine("Apologies, no heroes are currently available.");
        }
        else
        {
            heroelist.ForEach(WriteLine);
        }
    }

    public void GetMissionByOrder(TypeOrder type)
    {
        var missionlist = heroeRepository.GetMissionsOrderBy(type);
        if (missionlist == null || !missionlist.Any())
        {
            WriteLine("Apologies, no mission are currently available.");
        }
        else
        {
            missionlist.ForEach(WriteLine);
        }
    }

    public void AssingHeroe(string heroename, string missionname)
    { 
        var mission = _missions.FirstOrDefault(m => m.Name.Equals(missionname, StringComparison.OrdinalIgnoreCase));
        var heroe = _heroes.FirstOrDefault(m => m.Name.Equals(heroename, StringComparison.OrdinalIgnoreCase));
        if (mission==null)
        {
            WriteLine($"Mission with name: {missionname} doesnt exist ");
        }
        else
        {
            if (heroe == null)
            {
                WriteLine($"Heroe with name: {heroename} doesnt exist ");
            }
            else
            {
                heroeRepository.AddHeroeToMission(heroe, mission);
            }
        }
    }
    
    public void  CreateHeroe(Heroe heroe)
    {
        validator.ValidateHeroe(heroe); 
        heroeRepository.AddHeroe(heroe);
    }
    
    public void CreateMission(Mission mission)
    {
        validator.ValidateMission(mission); 
        heroeRepository.AddMission(mission);
    }
    
}