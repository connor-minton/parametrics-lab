using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle5Controller : ObstacleController
{
    public override float x(float t)
    {
        if (isFirstPeriod)
            return 3 * Mathf.Sin(Mathf.Pow(t, 1.8f)) + 20;
        return 3.5f * Mathf.Sin(7 * t);
    }

    public override float y(float t)
    {
        if (isFirstPeriod)
            return 3 * Mathf.Cos(t);
        return 5 * Mathf.Cos(7.5f * t);
    }
}
