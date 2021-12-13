using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle5Controller : MonoBehaviour
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
            return 3 * Mathf.Sin(Mathf.Pow(t, 1.8f)) + 20;
        return 3.5f * Mathf.Sin(7 * t);
    }

    public float y(float t)
    {
        if (isFirstPeriod)
            return 3 * Mathf.Cos(t);
        return 5 * Mathf.Cos(7.5f * t);
    }

    public float z(float t)
    {
        return 0.5f;
    }
}
