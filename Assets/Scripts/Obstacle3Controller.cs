using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle3Controller : MonoBehaviour
{
    private float currentTime;
    public bool isFirstPeriod;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(x(currentTime), z(currentTime), y(currentTime));
        currentTime += Time.deltaTime;
    }

    public float x(float t)
    {
        if (isFirstPeriod)
            return 3 * Mathf.Sin(t - 5) + 28;
        return 9 * Mathf.Sin(7 * t) + 10;
    }

    public float y(float t)
    {
        if (isFirstPeriod)
            return 5 * Mathf.Cos(6.5f * t);
        return 7 * Mathf.Cos(8 * t);
    }

    public float z(float t)
    {
        if (isFirstPeriod)
            return 0;
        return 0.5f;
    }
}
