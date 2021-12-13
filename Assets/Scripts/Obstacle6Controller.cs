using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle6Controller : MonoBehaviour
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
            return 15 * Mathf.Tan(Mathf.Pow(t, 1.4f));
        return 35 * Mathf.Pow(Mathf.Sin(20 * t), 2);
    }

    public float y(float t)
    {
        if (isFirstPeriod)
            return 4 * Mathf.Sin(Mathf.Pow(t, 1.4f));
        return 5 * Mathf.Cos(t);
    }

    public float z(float t)
    {
        return 0.5f;
    }
}
