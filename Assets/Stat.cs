using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat
{
    private int hp;
    private int energy;
    private int atk;
    private int spatk;
    private int def;
    private int spdef;
    private int spd;

    public Stat( int hp, int energy, int atk, int spatk, int def, int spdef, int spd )
    {
        this.hp = hp;
        this.energy = energy;
        this.atk = atk;
        this.spatk = spatk;
        this.def = def;
        this.spdef = spdef;
        this.spd = spd;
    }

    // GETTER FUNCTIONS

    public int getHp()
    {
        return this.hp;
    }

    public int getEnergy()
    {
        return this.energy;
    }

    public int getAtk()
    {
        return this.atk;
    }

    public int getSpatk()
    {
        return this.spatk;
    }

    public int getDef()
    {
        return this.def;
    }

    public int getSpdef()
    {
        return this.spdef;
    }

    public int getSpd()
    {
        return this.spd;
    }

    // SETTER FUNCTIONS

    public void setHp( int hp )
    {
        this.hp = hp;
    }

    public void setEnergy( int energy )
    {
        this.energy = energy;
    }

    public void setAtk( int atk )
    {
        this.atk = atk;
    }

    public void setSpatk( int spatk )
    {
        this.spatk = spatk;
    }

    public void setDef( int def)
    {
        this.def = def;
    }

    public void setSpdef( int spdef)
    {
        this.spdef = spdef;
    }

    public void setSpd( int spd)
    {
        this.spd = spd;
    }

}

