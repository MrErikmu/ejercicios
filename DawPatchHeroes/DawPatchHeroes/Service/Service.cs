
using DawPatchHeroes.Models;
using DawPatchHeroes.Repository;
using DawPatchHeroes.Validators;
using static System.Console;
namespace DawPatchHeroes.Service;

public class Service(IHeroeRepository heroeRepository, IValidator validator):IService
{
    private List<Heroe> _heroes = Factory.Factory.SeedHeroes();
    private List<Mission> _missions = Factory.Factory.SeedMission();
    
    public void ListAll()
    {
        heroeRepository.GetAllHeroes();
    }

    public void ShowRanking()
    {
        heroeRepository.GetHeroesOrderBy(type: TypeOrder.Heroebypowerlvl);
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
        var missionlist = heroeRepository.GetHeroesOrderBy(type);
        if (missionlist == null)
        {
            Console.WriteLine("Apologies, no mission are currently available.");
        }
        else
        {
            missionlist.ForEach(WriteLine);
        }
    }

    public void AssingHeroe(Heroe heroe, string namemission)
    { 
        
    }
    
    public void  CreateHeroe(Heroe heroe)
    {
        validator.ValidateHeroe(heroe); 
        heroeRepository.AddHeroe(heroe);
    }

    public void CreateMission()
    {
        throw new NotImplementedException();
    }

    public void CreateMission(Mission mission)
    {
        validator.ValidateMission(mission); 
        heroeRepository.AddMission(mission);
    }
    
}