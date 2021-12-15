using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle4Controller : ObstacleController
{
    public override float x(float t)
    {
        if (isFirstPeriod)
            return 3 * Mathf.Cos(3.5f * t);
        return 2 * Mathf.Sin(t * t) + 18;
    }

    public override float y(float t)
    {
        if (isFirstPeriod)
            return 5*Mathf.Sin(3.5f*t);
        return 10 * Mathf.Pow(Mathf.Cos(t), 2) - 5;
    }

    public override float z(float t)
    {
        if (isFirstPeriod)
            return Mathf.Abs(2*Mathf.Cos(3.5f*t))+0.5f;
        return 0.5f;
    }
}
