namespace DawPatchHeroes.Models;
/// <summary>
/// Subclase de heroe que se especializa en Fuerza física
/// </summary>
public class StrongMan:Heroe
{
    public override void Train()
    {
        var r = new Random();
        int result = r.Next(0, 100);
        var notification = result switch
        {
            <= 20 => CriticalFailure(),
            <= 90 => SuccessTrain(),
            _ => CriticalSuccess()
        };
    }
    private string CriticalFailure()
    {
        Hp -= Config.Config.StrongManBaseFailDmg;
        return $"¡Oh no! {Name} got injured during training and loses {Config.Config.StrongManBaseFailDmg} health points.";
    }

    private string SuccessTrain()
    {
        Exp += Config.Config.BaseHeroeExpGain;
        return $"¡ {Name} complete his training successfully and gain {Config.Config.BaseHeroeExpGain} exp points.";
    }

    private object CriticalSuccess()
    {
        Exp += Config.Config.BaseHeroeExpGain + Lvl;
        return $"¡ {Name} complete his training perfectly and gain {Config.Config.BaseHeroeExpGain+Lvl} exp points.";
    }
    public override void Rest()
    {
        Console.WriteLine($"{Name} is resting to recover heath");
        Hp = Config.Config.StrongManBaseHp * Lvl;
    }

    public override void GetPowerLvl()
    {
        Console.WriteLine($"{Name} power lvl is {PowerLvl} ");
    }
    public override void ShowStats()
    {
        Console.WriteLine(new string('-', 60));
        Console.WriteLine("{0,-15} | {1,-5} | {2,-5} | {3,-10} | {4,-5}", 
            "NAME", "LVL", "HP", "EXP", "POWER");
        Console.WriteLine(new string('-', 60));
        Console.WriteLine("{0,-15} | {1,-5} | {2,-5} | {3,-10} | {4,-5}", 
            Name, Lvl, Hp, Exp, PowerLvl);
        Console.WriteLine(new string('-', 60));
    }
    public override string ToString()
    {
       return $" Name: {Name}, LVL: {Lvl}, HP:{Hp}, Exp:{Exp}, PowerLvl: {PowerLvl}, ";
    }
}