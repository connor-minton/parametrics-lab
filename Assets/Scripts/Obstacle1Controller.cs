using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle1Controller : ObstacleController
{
    public override float x(float t)
    {
        if (isFirstPeriod)
            return -Mathf.Tan(t * t);
        return 5 * Mathf.Sin(t) + 15;
    }

    public override float y(float t)
    {
        if (isFirstPeriod)
            return -5 * Mathf.Sin(t);
        return 10 * Mathf.Cos(30 * t);
    }
}
