using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle4Controller : MonoBehaviour
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
            return 3 * Mathf.Cos(3.5f * t);
        return 2 * Mathf.Sin(t * t) + 18;
    }

    public float y(float t)
    {
        if (isFirstPeriod)
            return 5*Mathf.Sin(3.5f*t);
        return 10 * Mathf.Pow(Mathf.Cos(t), 2) - 5;
    }

    public float z(float t)
    {
        if (isFirstPeriod)
            return Mathf.Abs(2*Mathf.Cos(3.5f*t))+0.5f;
        return 0.5f;
    }
}
