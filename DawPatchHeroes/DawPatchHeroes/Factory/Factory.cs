using System.Security.Cryptography;
using DawPatchHeroes.Models;
using DawPatchHeroes.Repository;

namespace DawPatchHeroes.Factory;

public static class Factory
{
    public static List<Heroe> SeedHeroes()
    {
        List<Heroe> heroelist = new List<Heroe>();
        heroelist.AddRange(new List<Heroe>
        {
            new MasterMind { Name = "Aeliana Frost", Hp = 10, Exp = 0, Lvl = 1, PowerLvl = 1 },
            new StrongMan { Name = "Jaxom Ember", Hp = 50, Exp = 0, Lvl = 1, PowerLvl = 1 },
            new Rogue { Name = "Kaelen Voidwalker", Hp = 60, Exp = 0, Lvl = 2, PowerLvl = 2 },
            new StrongMan { Name = "Thorne Ironbark", Hp = 150, Exp = 0, Lvl = 3, PowerLvl = 3 },
            new Rogue() { Name = "Serafina Bright", Hp = 80, Exp = 0, Lvl = 4, PowerLvl = 4 }
        });
        return heroelist;
    }

    public static List<Mission>SeedMission()
    {
        List<Mission> missionlist = new List<Mission>();
        missionlist.AddRange(new List<Mission>
        {
            new Mission
            {
                Name = "Boar Hunting",
                Difficulty = 1,
                Status = MisionStatus.Complete,
                CollabRequired = false,
                Team = new List<Heroe> 
                {
                    new Rogue { Name = "Kaelen Voidwalker", Hp = 60, Exp = 0, Lvl = 2, PowerLvl = 2 },
                    new StrongMan { Name = "Thorne Ironbark", Hp = 150, Exp = 0, Lvl = 3, PowerLvl = 3 }
                }
            },
            new Mission
            {
                Name = "The Siege of Ironroot Grove",
                Difficulty = 6,
                Status = MisionStatus.Ongoing,
                CollabRequired = true,
                Team = new List<Heroe>
                {
                    new MasterMind { Name = "Aeliana Frost", Hp = 10, Exp = 0, Lvl = 1, PowerLvl = 1 },
                    new StrongMan { Name = "Jaxom Ember", Hp = 50, Exp = 0, Lvl = 1, PowerLvl = 1 },
                    new Rogue { Name = "Serafina Bright", Hp = 80, Exp = 0, Lvl = 4, PowerLvl = 4 }
                }
            }
        });
       return missionlist;
    }
}