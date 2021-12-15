using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle6Controller : ObstacleController
{
    public override float x(float t)
    {
        if (isFirstPeriod)
            return 15 * Mathf.Tan(Mathf.Pow(t, 1.4f));
        return 35 * Mathf.Pow(Mathf.Sin(20 * t), 2);
    }

    public override float y(float t)
    {
        if (isFirstPeriod)
            return 4 * Mathf.Sin(Mathf.Pow(t, 1.4f));
        return 5 * Mathf.Cos(t);
    }
}
