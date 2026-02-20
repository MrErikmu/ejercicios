namespace DawPatchHeroes.Models;

public abstract class Heroe
{
    public String Name { get; set; }
    public int Lvl { get; set; }
    public int Energy { get; set; }
    public int Exp { get; set; }
    public int BasePower { get; set; }

    public virtual void Train()
    {
        
    }

    public virtual void Rest()
    {
        
    }

    public virtual void GetPowerLvl()
    {
        
    }
    public virtual void ShowStats()
    {
        
    }
}