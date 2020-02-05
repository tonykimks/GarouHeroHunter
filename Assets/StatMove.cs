using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatMove : Move
{
    private bool increase;
    private Resources.StatType[] stats;
    private int factor;

    public StatMove(string name, Resources.Type type, bool target, int accuracy, bool requireAim, int order, int cost, int penalty, bool increase, Resources.StatType[] stats, int factor) : base(name, type, target, accuracy, requireAim, order, cost, penalty)
    {
        this.increase = increase;
        this.stats = stats;
        this.factor = factor;
    }

    public bool getIncrease()
    {
        return this.increase;
    }

    public Resources.StatType[] getStats()
    {
        return this.stats;
    }

    public int getFactor()
    {
        return this.factor;
    }

}
