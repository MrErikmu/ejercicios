namespace DawPatchHeroes.Models;
/// <summary>
/// Clase que define las misiones a las que los heroes pueden acceder, si la misión fracasa los heroes
/// perderan 1pto de energía por nivel de dificultad
/// <param name="Difficulty">La dificultad de las misiones debe estar comprendida entre 1 y 10 </param>
/// </summary>
public class Mission
{
    public string Name { get; set; }
    public int Difficulty { get; set; }
    public MisionStatus Status { get; set; }
    public List<Heroe> Team { get; set; }
    public bool CollabRequited { get; set; }

    public void SumulateMission(Mission mission)
    {
        var count = 0;
        foreach (var h in Team)
        {
            count += h.Lvl;
        }
        if (count>= mission.Difficulty)
        {
            Console.WriteLine("Mission Success Great job team");
            mission.Status = MisionStatus.Complete;
        }
        else
        {
            Console.WriteLine("Mission Fail Better luck next time");
        }
    }
}