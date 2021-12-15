using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle2Controller : ObstacleController
{
    public override float x(float t)
    {
        if (isFirstPeriod)
            return 17 * Mathf.Sin(5f / 3 * t) + 17.5f;
        return 5 * Mathf.Cos(10 * t) + 17.5f;
    }

    public override float y(float t)
    {
        if (isFirstPeriod)
            return 5 * Mathf.Cos(3 * t);
        return Mathf.Floor(5 * Mathf.Sin(10 * t)) + 0.5f;
    }
}

