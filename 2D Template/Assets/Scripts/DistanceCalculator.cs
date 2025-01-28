using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class DistanceCalculator : MonoBehaviour
{
    public GameObject findObject;

    // Update is called once per frame
    void Start()
    {
        float x1 = findObject.transform.position.x;
        float y1 = findObject.transform.position.y;
        float z1 = findObject.transform.position.z;

        float x2 = gameObject.transform.position.x;
        float y2 = gameObject.transform.position.y;
        float z2 = gameObject.transform.position.z;

        Distance(x1, y1, z1, x2, y2, z2);
    }

    public static void Distance(float x1, float y1, float z1, float x2, float y2, float z2)
    {
        float distanceX = x2 - x1;
        float distanceY = y2 - y1;
        float distanceZ = z2 - z1;

        float squaredX = distanceX * distanceX;
        float squaredY = distanceY * distanceY;
        float squaredZ = distanceZ * distanceZ;

        float addedValues = squaredX + squaredY + squaredZ;

        float c = Mathf.Sqrt(addedValues);

        Debug.Log(c);
    }
}
