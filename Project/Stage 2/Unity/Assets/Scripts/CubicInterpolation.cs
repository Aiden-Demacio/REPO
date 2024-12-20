using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CubicInterpolation : MonoBehaviour
{
    [SerializeField] Transform[] points;
    private int length;

    [SerializeField] private float t;
    [SerializeField] private float speed = 1;
    [SerializeField] private int index;

    public bool IsPlayerRiding;

    // Update is called once per frame
    void Update()
    {
        if (IsPlayerRiding)
            t += Time.deltaTime * speed;
        if (t > 1)
        {
            t = 0;
            index++;
        }
        else if (t < 0)
        {
            t = 1;
            index--;
        }

        if (IsPlayerRiding)
        {
            transform.position = CatmullRomPosition(index, t);
            transform.LookAt(CatmullRomPosition(index, t + 0.01f));
            transform.rotation *= Quaternion.Euler(-90, 0, 0);
        }
        
    }
    
    private Vector3 CatmullRomPosition(int i, float t)
    {
        Vector3 p0 = points[i % points.Length].position;
        Vector3 p1 = points[(i + 1) % points.Length].position;
        Vector3 p2 = points[(i + 2) % points.Length].position;
        Vector3 p3 = points[(i + 3) % points.Length].position;
        
        float t2 = t * t;
        float t3 = t2 * t;

        Vector3 position = 0.5f * (
            2f * p1 +
            (-p0 + p2) * t +
            (2f * p0 - 5f * p1 + 4f * p2 - p3) * t2 +
            (-p0 + 3f * p1 - 3f * p2 + p3) * t3
        );

        return position;
    }
}
