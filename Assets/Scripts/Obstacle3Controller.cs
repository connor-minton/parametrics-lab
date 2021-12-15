using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle3Controller : ObstacleController
{
    public override float x(float t)
    {
        if (isFirstPeriod)
            return 3 * Mathf.Sin(t - 5) + 28;
        return 9 * Mathf.Sin(7 * t) + 10;
    }

    public override float y(float t)
    {
        if (isFirstPeriod)
            return 5 * Mathf.Cos(6.5f * t);
        return 7 * Mathf.Cos(8 * t);
    }

    public override float z(float t)
    {
        if (isFirstPeriod)
            return 0;
        return 0.5f;
    }
}
