using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources 
{
    public enum Type
    {
        Normal,
        Fight,
        Flying,
        Poison,
        Ground,
        TheRock,
        Bug, 
        Ghost, 
        Steel,
        Fire,
        Water,
        Grass, 
        Electric,
        Psychic,
        Ice,
        Monster,
        Dark,
        Fairy,
        None
    }

    public enum Effectiveness
    {
        Super,
        Weak,
        Normal,
        None
    }

    public static Dictionary<Type, Dictionary<Type, Effectiveness>> typeChart = new Dictionary<Type, Dictionary<Type, Effectiveness>>()
    {
        { Type.Normal, new Dictionary<Type, Effectiveness>()
            {
                { Type.Normal, Effectiveness.Normal },
                { Type.Fight, Effectiveness.Weak },
                { Type.Flying, Effectiveness.Normal },
                { Type.Poison, Effectiveness.Normal },
                { Type.Ground, Effectiveness.Normal },
                { Type.TheRock, Effectiveness.Weak },
                { Type.Bug, Effectiveness.Normal },
                { Type.Ghost, Effectiveness.None },
                { Type.Steel, Effectiveness.Weak },
                { Type.Fire, Effectiveness.Normal },
                { Type.Water, Effectiveness.Normal },
                { Type.Grass, Effectiveness.Normal },
                { Type.Electric, Effectiveness.Normal },
                { Type.Psychic, Effectiveness.Normal },
                { Type.Ice, Effectiveness.Normal },
                { Type.Monster, Effectiveness.Weak },
                { Type.Dark, Effectiveness.Normal },
                { Type.Fairy, Effectiveness.Normal }
            }
        },
        { Type.Fight, new Dictionary<Type, Effectiveness>()
            {
                { Type.Normal, Effectiveness.Super },
                { Type.Fight, Effectiveness.Normal },
                { Type.Flying, Effectiveness.Weak },
                { Type.Poison, Effectiveness.Weak },
                { Type.Ground, Effectiveness.Normal },
                { Type.TheRock, Effectiveness.Super },
                { Type.Bug, Effectiveness.Weak },
                { Type.Ghost, Effectiveness.None },
                { Type.Steel, Effectiveness.Weak },
                { Type.Fire, Effectiveness.Normal },
                { Type.Water, Effectiveness.Normal },
                { Type.Grass, Effectiveness.Normal },
                { Type.Electric, Effectiveness.Normal },
                { Type.Psychic, Effectiveness.Weak },
                { Type.Ice, Effectiveness.Super },
                { Type.Monster, Effectiveness.Weak },
                { Type.Dark, Effectiveness.Super },
                { Type.Fairy, Effectiveness.Normal }
            }
        },
        { Type.Flying, new Dictionary<Type, Effectiveness>()
            {
                { Type.Normal, Effectiveness.Normal },
                { Type.Fight, Effectiveness.Super },
                { Type.Flying, Effectiveness.Normal },
                { Type.Poison, Effectiveness.Normal },
                { Type.Ground, Effectiveness.Normal },
                { Type.TheRock, Effectiveness.Normal },
                { Type.Bug, Effectiveness.Super },
                { Type.Ghost, Effectiveness.Normal },
                { Type.Steel, Effectiveness.Weak },
                { Type.Fire, Effectiveness.Normal },
                { Type.Water, Effectiveness.Normal },
                { Type.Grass, Effectiveness.Super },
                { Type.Electric, Effectiveness.Weak },
                { Type.Psychic, Effectiveness.Normal },
                { Type.Ice, Effectiveness.Normal },
                { Type.Monster, Effectiveness.Normal },
                { Type.Dark, Effectiveness.Normal },
                { Type.Fairy, Effectiveness.Normal }
            }
        },
        { Type.Poison, new Dictionary<Type, Effectiveness>()
            {
                { Type.Normal, Effectiveness.Normal },
                { Type.Fight, Effectiveness.Normal },
                { Type.Flying, Effectiveness.Normal },
                { Type.Poison, Effectiveness.Weak },
                { Type.Ground, Effectiveness.Weak },
                { Type.TheRock, Effectiveness.Weak },
                { Type.Bug, Effectiveness.Normal },
                { Type.Ghost, Effectiveness.Weak },
                { Type.Steel, Effectiveness.None },
                { Type.Fire, Effectiveness.Normal },
                { Type.Water, Effectiveness.Normal },
                { Type.Grass, Effectiveness.Super },
                { Type.Electric, Effectiveness.Normal },
                { Type.Psychic, Effectiveness.Normal },
                { Type.Ice, Effectiveness.Normal },
                { Type.Monster, Effectiveness.Normal },
                { Type.Dark, Effectiveness.Normal },
                { Type.Fairy, Effectiveness.Super }
            }
        },
        { Type.Ground, new Dictionary<Type, Effectiveness>()
            {
                { Type.Normal, Effectiveness.Normal },
                { Type.Fight, Effectiveness.Normal },
                { Type.Flying, Effectiveness.None },
                { Type.Poison, Effectiveness.Super },
                { Type.Ground, Effectiveness.Normal },
                { Type.TheRock, Effectiveness.Normal },
                { Type.Bug, Effectiveness.Weak },
                { Type.Ghost, Effectiveness.Normal },
                { Type.Steel, Effectiveness.Super },
                { Type.Fire, Effectiveness.Super },
                { Type.Water, Effectiveness.Normal },
                { Type.Grass, Effectiveness.Weak },
                { Type.Electric, Effectiveness.Super },
                { Type.Psychic, Effectiveness.Normal },
                { Type.Ice, Effectiveness.Normal },
                { Type.Monster, Effectiveness.Normal },
                { Type.Dark, Effectiveness.Normal },
                { Type.Fairy, Effectiveness.Normal }
            }
        },
        { Type.TheRock, new Dictionary<Type, Effectiveness>()
            {
                { Type.Normal, Effectiveness.Super },
                { Type.Fight, Effectiveness.Weak },
                { Type.Flying, Effectiveness.Normal },
                { Type.Poison, Effectiveness.Normal },
                { Type.Ground, Effectiveness.Normal },
                { Type.TheRock, Effectiveness.Normal },
                { Type.Bug, Effectiveness.Super },
                { Type.Ghost, Effectiveness.Normal },
                { Type.Steel, Effectiveness.Weak },
                { Type.Fire, Effectiveness.Normal },
                { Type.Water, Effectiveness.Normal },
                { Type.Grass, Effectiveness.Super },
                { Type.Electric, Effectiveness.Normal },
                { Type.Psychic, Effectiveness.Normal },
                { Type.Ice, Effectiveness.Super },
                { Type.Monster, Effectiveness.Normal },
                { Type.Dark, Effectiveness.Normal },
                { Type.Fairy, Effectiveness.Normal }
            }
        },
        { Type.Bug, new Dictionary<Type, Effectiveness>()
            {
                { Type.Normal, Effectiveness.Normal },
                { Type.Fight, Effectiveness.Weak },
                { Type.Flying, Effectiveness.Weak },
                { Type.Poison, Effectiveness.Weak },
                { Type.Ground, Effectiveness.Normal },
                { Type.TheRock, Effectiveness.Normal },
                { Type.Bug, Effectiveness.Normal },
                { Type.Ghost, Effectiveness.Weak },
                { Type.Steel, Effectiveness.Weak },
                { Type.Fire, Effectiveness.Weak },
                { Type.Water, Effectiveness.Normal },
                { Type.Grass, Effectiveness.Super },
                { Type.Electric, Effectiveness.Normal },
                { Type.Psychic, Effectiveness.Super },
                { Type.Ice, Effectiveness.Normal },
                { Type.Monster, Effectiveness.Weak },
                { Type.Dark,  Effectiveness.Super },
                { Type.Fairy,  Effectiveness.Weak }
            }
        },
        { Type.Ghost, new Dictionary<Type, Effectiveness>()
            {
                { Type.Normal, Effectiveness.None },
                { Type.Fight, Effectiveness.Normal },
                { Type.Flying, Effectiveness.Normal },
                { Type.Poison, Effectiveness.Normal },
                { Type.Ground, Effectiveness.Normal },
                { Type.TheRock, Effectiveness.Normal },
                { Type.Bug, Effectiveness.Normal },
                { Type.Ghost, Effectiveness.Super },
                { Type.Steel, Effectiveness.Normal },
                { Type.Fire, Effectiveness.Normal },
                { Type.Water, Effectiveness.Normal },
                { Type.Grass, Effectiveness.Normal },
                { Type.Electric, Effectiveness.Normal },
                { Type.Psychic, Effectiveness.Super },
                { Type.Ice, Effectiveness.Normal },
                { Type.Monster, Effectiveness.Normal },
                { Type.Dark, Effectiveness.Weak },
                { Type.Fairy, Effectiveness.Normal }
            }
        },
        { Type.Steel, new Dictionary<Type, Effectiveness>()
            {
                { Type.Normal, Effectiveness.Normal },
                { Type.Fight, Effectiveness.Normal },
                { Type.Flying, Effectiveness.Normal },
                { Type.Poison, Effectiveness.Normal },
                { Type.Ground, Effectiveness.Normal },
                { Type.TheRock, Effectiveness.Super },
                { Type.Bug, Effectiveness.Normal },
                { Type.Ghost, Effectiveness.Normal},
                { Type.Steel, Effectiveness.Weak },
                { Type.Fire, Effectiveness.Weak },
                { Type.Water, Effectiveness.Weak },
                { Type.Grass, Effectiveness.Normal },
                { Type.Electric, Effectiveness.Weak },
                { Type.Psychic, Effectiveness.Normal },
                { Type.Ice, Effectiveness.Super },
                { Type.Monster, Effectiveness.Normal },
                { Type.Dark, Effectiveness.Normal },
                { Type.Fairy,Effectiveness.Super }
            }
        },
        { Type.Fire, new Dictionary<Type, Effectiveness>()
            {
                { Type.Normal, Effectiveness.Normal },
                { Type.Fight, Effectiveness.Normal },
                { Type.Flying, Effectiveness.Normal },
                { Type.Poison, Effectiveness.Normal },
                { Type.Ground, Effectiveness.Normal },
                { Type.TheRock, Effectiveness.Normal },
                { Type.Bug, Effectiveness.Super },
                { Type.Ghost, Effectiveness.Normal },
                { Type.Steel, Effectiveness.Super },
                { Type.Fire, Effectiveness.Weak },
                { Type.Water, Effectiveness.Weak },
                { Type.Grass, Effectiveness.Super },
                { Type.Electric, Effectiveness.Normal },
                { Type.Psychic, Effectiveness.Normal },
                { Type.Ice, Effectiveness.Super },
                { Type.Monster, Effectiveness.Weak },
                { Type.Dark, Effectiveness.Normal },
                { Type.Fairy, Effectiveness.Normal }
            }
        },
        { Type.Water, new Dictionary<Type, Effectiveness>()
            {
                { Type.Normal, Effectiveness.Normal },
                { Type.Fight, Effectiveness.Normal },
                { Type.Flying, Effectiveness.Normal },
                { Type.Poison, Effectiveness.Normal },
                { Type.Ground, Effectiveness.Super },
                { Type.TheRock, Effectiveness.Normal },
                { Type.Bug, Effectiveness.Normal },
                { Type.Ghost, Effectiveness.Normal },
                { Type.Steel, Effectiveness.Super },
                { Type.Fire, Effectiveness.Super },
                { Type.Water, Effectiveness.Weak },
                { Type.Grass, Effectiveness.Weak },
                { Type.Electric, Effectiveness.Normal },
                { Type.Psychic, Effectiveness.Normal },
                { Type.Ice, Effectiveness.Normal },
                { Type.Monster, Effectiveness.Weak },
                { Type.Dark, Effectiveness.Normal },
                { Type.Fairy, Effectiveness.Normal }
            }
        },
        { Type.Grass, new Dictionary<Type, Effectiveness>()
            {
                { Type.Normal, Effectiveness.Normal },
                { Type.Fight, Effectiveness.Normal },
                { Type.Flying, Effectiveness.Weak },
                { Type.Poison, Effectiveness.Weak },
                { Type.Ground, Effectiveness.Super },
                { Type.TheRock, Effectiveness.Normal },
                { Type.Bug, Effectiveness.Weak },
                { Type.Ghost, Effectiveness.Normal },
                { Type.Steel, Effectiveness.Weak },
                { Type.Fire, Effectiveness.Weak },
                { Type.Water, Effectiveness.Super },
                { Type.Grass, Effectiveness.Weak },
                { Type.Electric, Effectiveness.Normal },
                { Type.Psychic, Effectiveness.Normal },
                { Type.Ice, Effectiveness.Normal },
                { Type.Monster, Effectiveness.Weak },
                { Type.Dark, Effectiveness.Normal },
                { Type.Fairy, Effectiveness.Normal }
            }
        },
        { Type.Electric, new Dictionary<Type, Effectiveness>()
            {
                { Type.Normal, Effectiveness.Normal },
                { Type.Fight, Effectiveness.Normal },
                { Type.Flying, Effectiveness.Super },
                { Type.Poison, Effectiveness.Normal },
                { Type.Ground, Effectiveness.None },
                { Type.TheRock, Effectiveness.Normal },
                { Type.Bug, Effectiveness.Normal },
                { Type.Ghost, Effectiveness.Normal },
                { Type.Steel, Effectiveness.Normal },
                { Type.Fire, Effectiveness.Normal },
                { Type.Water, Effectiveness.Super },
                { Type.Grass, Effectiveness.Weak },
                { Type.Electric, Effectiveness.Weak },
                { Type.Psychic, Effectiveness.Normal },
                { Type.Ice, Effectiveness.Normal },
                { Type.Monster, Effectiveness.Weak },
                { Type.Dark, Effectiveness.Normal },
                { Type.Fairy, Effectiveness.Normal }
            }
        },
        { Type.Psychic, new Dictionary<Type, Effectiveness>()
            {
                { Type.Normal, Effectiveness.Super },
                { Type.Fight, Effectiveness.Super },
                { Type.Flying, Effectiveness.Normal },
                { Type.Poison, Effectiveness.Super },
                { Type.Ground, Effectiveness.Normal },
                { Type.TheRock, Effectiveness.Super },
                { Type.Bug, Effectiveness.Normal },
                { Type.Ghost, Effectiveness.Normal },
                { Type.Steel, Effectiveness.Weak },
                { Type.Fire, Effectiveness.Normal },
                { Type.Water, Effectiveness.Normal },
                { Type.Grass, Effectiveness.Normal },
                { Type.Electric, Effectiveness.Normal },
                { Type.Psychic, Effectiveness.Weak },
                { Type.Ice, Effectiveness.Normal },
                { Type.Monster, Effectiveness.Super },
                { Type.Dark, Effectiveness.None },
                { Type.Fairy, Effectiveness.Normal }
            }
        },
        { Type.Ice, new Dictionary<Type, Effectiveness>()
            {
                { Type.Normal, Effectiveness.Normal },
                { Type.Fight, Effectiveness.Normal },
                { Type.Flying, Effectiveness.Super },
                { Type.Poison, Effectiveness.Normal },
                { Type.Ground, Effectiveness.Super },
                { Type.TheRock, Effectiveness.Normal },
                { Type.Bug, Effectiveness.Normal },
                { Type.Ghost, Effectiveness.Normal },
                { Type.Steel, Effectiveness.Weak },
                { Type.Fire, Effectiveness.Weak },
                { Type.Water, Effectiveness.Weak },
                { Type.Grass, Effectiveness.Super },
                { Type.Electric, Effectiveness.Normal },
                { Type.Psychic, Effectiveness.Normal },
                { Type.Ice, Effectiveness.Weak },
                { Type.Monster, Effectiveness.Normal },
                { Type.Dark, Effectiveness.Normal },
                { Type.Fairy, Effectiveness.Normal }
            }
        },
        { Type.Monster, new Dictionary<Type, Effectiveness>()
            {
                { Type.Normal, Effectiveness.Super },
                { Type.Fight, Effectiveness.Normal },
                { Type.Flying, Effectiveness.Normal },
                { Type.Poison, Effectiveness.Normal },
                { Type.Ground, Effectiveness.Normal },
                { Type.TheRock, Effectiveness.Normal },
                { Type.Bug, Effectiveness.Normal },
                { Type.Ghost, Effectiveness.Normal },
                { Type.Steel, Effectiveness.Weak },
                { Type.Fire, Effectiveness.Normal },
                { Type.Water, Effectiveness.Normal },
                { Type.Grass, Effectiveness.Normal },
                { Type.Electric, Effectiveness.Normal },
                { Type.Psychic, Effectiveness.Weak },
                { Type.Ice, Effectiveness.Normal },
                { Type.Monster, Effectiveness.Super },
                { Type.Dark, Effectiveness.Normal },
                { Type.Fairy, Effectiveness.Weak }
            }
        },
        { Type.Dark, new Dictionary<Type, Effectiveness>()
            {
                { Type.Normal, Effectiveness.Normal },
                { Type.Fight, Effectiveness.Weak },
                { Type.Flying, Effectiveness.Normal },
                { Type.Poison, Effectiveness.Normal },
                { Type.Ground, Effectiveness.Normal },
                { Type.TheRock, Effectiveness.Normal },
                { Type.Bug, Effectiveness.Normal },
                { Type.Ghost, Effectiveness.Super },
                { Type.Steel, Effectiveness.Normal },
                { Type.Fire, Effectiveness.Normal },
                { Type.Water, Effectiveness.Normal },
                { Type.Grass, Effectiveness.Normal },
                { Type.Electric, Effectiveness.Normal },
                { Type.Psychic, Effectiveness.Super },
                { Type.Ice, Effectiveness.Normal },
                { Type.Monster, Effectiveness.Normal },
                { Type.Dark, Effectiveness.Weak },
                { Type.Fairy, Effectiveness.Weak }
            }
        },
        { Type.Fairy, new Dictionary<Type, Effectiveness>()
            {
                { Type.Normal, Effectiveness.Normal },
                { Type.Fight, Effectiveness.Super },
                { Type.Flying, Effectiveness.Normal },
                { Type.Poison, Effectiveness.Weak },
                { Type.Ground, Effectiveness.Normal },
                { Type.TheRock, Effectiveness.Normal },
                { Type.Bug, Effectiveness.Normal },
                { Type.Ghost, Effectiveness.Normal },
                { Type.Steel, Effectiveness.Weak },
                { Type.Fire, Effectiveness.Weak },
                { Type.Water, Effectiveness.Normal },
                { Type.Grass, Effectiveness.Normal },
                { Type.Electric, Effectiveness.Normal },
                { Type.Psychic, Effectiveness.Normal },
                { Type.Ice, Effectiveness.Normal },
                { Type.Monster, Effectiveness.Super },
                { Type.Dark, Effectiveness.Super },
                { Type.Fairy, Effectiveness.Normal }
            }
        }
    };

    public enum Status
    {
        Healthy,
        Paralyze,
        Poison,
        Burn
    }

    public enum StatType
    {
        Hp,
        Energy,
        Atk,
        Spatk,
        Def,
        Spdef,
        Spd
    }

    public enum Rank
    {
        S,
        A,
        B,
        C,
        None
    }


    /* Move List
     * Parameters:
     * 
     * DAMAGE MOVE:
     * int name
     * Type type
     * target
     * accuracy
     * requireAim
     * order
     * cost
     * penalty
     * physical 
     * damage
     * crit rate
     * numHits
     * oneHitKO
     */
    public static Move waterStreamFist = new DamageMove("Water Stream Rock Smashing Fist", Type.Poison, true, 90, true, 0, 20, 8, true, 100, 6, 1, false);
    public static Move machineGunBlows = new DamageMove("Machine Gun Blows", Type.Psychic, true, 85, true, 0, 13, 5, true, 80, 6, 1, false);

    public static Move bulkUp = new Move("Bulk Up", Type.Fight, false, 100, true, 0, 5, 3);
    public static Move firePunch = new DamageMove("Fire Punch", Type.Fire, true, 70, true, 0, 8, 6, true, 60, 6, 1, false);
    public static Move crossChop = new DamageMove("Cross Chop", Type.Fight, true, 75, true, 0, 15, 12, true, 90, 6, 1, false);
}
