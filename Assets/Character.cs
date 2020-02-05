using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character 
{
    private Resources.Type type1;
    private Resources.Type type2;
    private string name;
    private Resources.Rank rank;
    private int level;
    Stat originalStats;
    Stat currentStats;
    Move[] currentMoves;
    Dictionary<int, Move> allMoves;
    Resources.Status status;

    public Character(   Resources.Type type1, 
                        Resources.Type type2, 
                        string name,
                        Resources.Rank rank, 
                        int level, 
                        Stat originalStats,
                        Move[] currentMoves, 
                        Dictionary<int, Move> allMoves, 
                        Resources.Status status )
    {
        this.type1 = type1;
        this.type2 = type2;
        this.name = name;
        this.rank = rank;
        this.level = level;
        this.originalStats = originalStats;
        this.currentStats = new Stat(originalStats.getHp(), originalStats.getEnergy(), originalStats.getAtk(), originalStats.getSpatk(), originalStats.getDef(), originalStats.getSpdef(), originalStats.getSpd());
        this.currentMoves = currentMoves;
        this.allMoves = allMoves;
        this.status = status;
    }

    // GETTER FUNCTIONS

    public bool hasTwoTypes()
    {
        return this.type2 == Resources.Type.None;
    }

    public Resources.Type getType1()
    {
        return this.type1;
    }

    public Resources.Type getType2()
    {
        return this.type2;
    }

    public string getName()
    {
        return this.name;
    }

    public Resources.Rank getRank()
    {
        return this.rank;
    }

    public int getLevel()
    {
        return this.level;
    }

    public Stat getOriginalStats()
    {
        return this.originalStats;
    }

    public Stat getCurrentStats()
    {
        return this.currentStats;
    }

    public Move[] getMoves()
    {
        return this.currentMoves;
    }

    public Dictionary<int, Move> getMoveList()
    {
        return this.allMoves;
    }

    public Resources.Status getStatus()
    {
        return this.status;
    }

    // SETTER FUNCTIONS

    public void setCurrentStats( int hp, int energy, int atk, int spatk, int def, int spdef, int spd )
    {
        this.currentStats.setHp(hp);
        this.currentStats.setEnergy(energy);
        this.currentStats.setAtk(atk);
        this.currentStats.setSpatk(spatk);
        this.currentStats.setDef(def);
        this.currentStats.setSpdef(spdef);
        this.currentStats.setSpd(spd);
    }

    public void setOriginalStats( int hp, int energy, int atk, int spatk, int def, int spdef, int spd )
    {
        this.originalStats.setHp(hp);
        this.originalStats.setEnergy(energy);
        this.originalStats.setAtk(atk);
        this.originalStats.setSpatk(spatk);
        this.originalStats.setDef(def);
        this.originalStats.setSpdef(spdef);
        this.originalStats.setSpd(spd);
    }

    public void setRank( Resources.Rank rank)
    {
        this.rank = rank;
    }

    public void setLevel( int level )
    {
        this.level = level;
    }

    public void setMoves( Move[] moves)
    {
        this.currentMoves = moves;
    }

    public void setStatus( Resources.Status status)
    {
        this.status = status;
    }
}
