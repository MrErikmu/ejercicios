using DawPatchHeroes.Models;

namespace DawPatchHeroes.Service;

public interface IService
{
    public void ListAll();
    public void ShowRanking();
    public void GetHeroeByOrder(TypeOrder type);
    public void GetMissionByOrder(TypeOrder type); 
    public void AssingHeroe(Heroe heroe, string namemission);
    public void CreateHeroe(Heroe newheroe);
    public void CreateMission();
}