using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle1Controller : MonoBehaviour
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
            return -Mathf.Tan(t * t);
        return 5 * Mathf.Sin(t) + 15;
    }

    public float y(float t)
    {
        if (isFirstPeriod)
            return -5 * Mathf.Sin(t);
        return 10 * Mathf.Cos(30 * t);
    }

    public float z(float t)
    {
        return 0.5f;
    }
}
