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
    public bool CollabRequired { get; set; }

    public void SumulateMission()
    {
        var totalheroes = Team.Count; 
        var totallvl = 0;
        foreach (var h in Team)
        {
            totallvl += h.Lvl;
        }
        if (totallvl>= this.Difficulty)
        {
            Console.WriteLine("Mission Success Great job team");
            Status = MisionStatus.Complete;
            foreach (var h in Team)
            {
                h.Exp += Config.Config.BaseHeroeExpGain * Difficulty;
            }
        }
        else
        {
            Console.WriteLine("Mission Fail Better luck next time");
            foreach (var h in Team)
            {
                h.Hp -= (Config.Config.BaseMissionDmg * Difficulty)/totalheroes;
            }
        }
    }
    public override string ToString()
    {
        var teamNames = string.Join(", ", Team.Select(h => h.Name));
           
        string required;
        if (CollabRequired)
        {
            required = "Collab Requiered";
        }
        else
        {
            required = "Collab not Requiered";
        }
        return $" Name: {Name}, Dificulty:{Difficulty}, Mission Status: {Status}, Collab: {required} /n Assign Heroes:{teamNames}";
    }
}