using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusMove : Move
{
    private Resources.Status status;

    public StatusMove(string name, Resources.Type type, bool target, int accuracy, bool requireAim, int order, int cost, int penalty, Resources.Status status) : base(name, type, target, accuracy, requireAim, order, cost, penalty)
    {
        this.status = status;
    }

    public Resources.Status getStatus()
    {
        return this.status;
    }
}
