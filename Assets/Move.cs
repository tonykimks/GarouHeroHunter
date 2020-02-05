using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    private string name;
    private Resources.Type type;
    private bool target; // target is true if target is enemy
    private int accuracy;
    private bool requireAim;
    private int order;
    private int cost;
    private int penalty;

    public Move( string name, Resources.Type type, bool target, int accuracy, bool requireAim, int order, int cost, int penalty )
    {
        this.name = name;
        this.type = type;
        this.target = target;
        this.accuracy = accuracy;
        this.requireAim = requireAim;
        this.order = order;
        this.cost = cost;
        this.penalty = penalty;
    }

    // GETTER FUNCTIONS

    public string getName()
    {
        return this.name;
    }

    public Resources.Type getType()
    {
        return this.type;
    }

    public bool getTarget()
    {
        return this.target;
    }

    public int getAccuracy()
    {
        return this.accuracy;
    }

    public bool getRequireAim()
    {
        return this.requireAim;
    }

    public int getOrder()
    {
        return this.order;
    }

    public int getCost()
    {
        return this.cost;
    }

    public int getPenalty()
    {
        return this.penalty;
    }
}
