using DawPatchHeroes.Models;

namespace DawPatchHeroes.Service;

public interface IService
{
    public void ListAll();
    public void ShowRanking();
    public IEnumerable<Heroe> GetHeroeByOrder();
    public IEnumerable<Mission> GetMission(); 
    public void AssingHeroe(Heroe heroe);
    public void SimulateMission(string missionname);
    public Heroe CreateHeroe();
    public Mission CreateMission();
    public void UpdateMissionStatus(); 
}