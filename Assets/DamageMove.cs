using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMove : Move
{
    private bool physical;
    private int damage;
    private int critRate;
    private int numHits;
    private bool oneHitKO;

    public DamageMove(string name, Resources.Type type, bool target, int accuracy, bool requireAim, int order, int cost, int penalty, bool physical, int damage, int critRate, int numHits, bool oneHitKO) : base(name, type, target, accuracy, requireAim, order, cost, penalty)
    {
        this.physical = physical;
        this.damage = damage;
        this.critRate = critRate;
        this.numHits = numHits;
        this.oneHitKO = oneHitKO;
    }

    public bool getPhysical()
    {
        return this.physical;
    }

    public int getDamage()
    {
        return this.damage;
    }

    public int getCritRate()
    {
        return this.critRate;
    }

    public int getNumHits()
    {
        return this.numHits;
    }

    public bool getOneHitOK()
    {
        return this.oneHitKO;
    }
}
