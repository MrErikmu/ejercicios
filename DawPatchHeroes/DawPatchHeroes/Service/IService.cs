using DawPatchHeroes.Models;

namespace DawPatchHeroes.Service;

public interface IService
{
    public void ListAll();
    public void ShowRanking();
    public void SimulateMission(string missionname);
    public void GetHeroeByOrder(TypeOrder type);
    public void GetMissionByOrder(TypeOrder type); 
    public void AssingHeroe(string heroename, string namemission);
    public void CreateHeroe(Heroe newheroe);
    public void CreateMission(Mission mission);
}