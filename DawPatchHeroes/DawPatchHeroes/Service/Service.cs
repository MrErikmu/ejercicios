using DawPatchHeroes.Factory;
using DawPatchHeroes.Models;
using DawPatchHeroes.Repository;
using DawPatchHeroes.Validators;

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
        heroeRepository.GetHeroeOrderByPower();
    }

    public IEnumerable<Heroe> GetHeroeByOrder()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Mission> GetMission()
    {
        throw new NotImplementedException();
    }

    public void AssingHeroe(Heroe heroe)
    {
        throw new NotImplementedException();
    }

    public void SimulateMission(string missionname)
    {
        throw new NotImplementedException();
    }

    public Heroe CreateHeroe()
    {
        throw new NotImplementedException();
    }

    public Mission CreateMission()
    {
        throw new NotImplementedException();
    }

    public void UpdateMissionStatus()
    {
        throw new NotImplementedException();
    }
}