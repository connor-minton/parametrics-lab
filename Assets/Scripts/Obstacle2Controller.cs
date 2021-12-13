using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle2Controller : MonoBehaviour
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
            return 17 * Mathf.Sin(5f / 3 * t) + 17.5f;
        return 5 * Mathf.Cos(10 * t) + 17.5f;
    }

    public float y(float t)
    {
        if (isFirstPeriod)
            return 5 * Mathf.Cos(3 * t);
        return Mathf.Floor(5 * Mathf.Sin(10 * t)) + 0.5f;
    }

    public float z(float t)
    {
        return 0.5f;
    }
}

