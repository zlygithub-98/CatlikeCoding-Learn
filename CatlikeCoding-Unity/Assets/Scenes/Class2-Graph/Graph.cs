using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField] private Transform pointPrefab;

    //必须在10-100之间
    [SerializeField, Range(10, 100)] private int resolution = 10;
    [SerializeField] FunctionLibrary.FunctionName function;

    Transform[] points;

    void Awake()
    {
        float step = 2f / resolution;
        Vector3 position = Vector3.zero;
        var scale = Vector3.one * step;
        points = new Transform[resolution * resolution];
        for (int i = 0, x = 0, z = 0; i < points.Length; i++, x++)
        {
            if (x == resolution)
            {
                x = 0;
                z += 1;
            }

            //如果我们连续多次分配相同的内容，我们可以将这些分配链接在一起，因为分配表达式的结果就是分配的结果
            Transform point = points[i] = Instantiate(pointPrefab);
            position.x = (x + 0.5f) * step - 1f;
            position.z = (z + 0.5f) * step - 1f;
            point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform, false);
        }
    }

    private void Update()
    {
        FunctionLibrary.Function f = FunctionLibrary.GetFunction(function);
        float time = Time.time;
        float step = 2f / resolution;
        float v = 0.5f * step - 1;
        for (int i = 0,x=0,z=0; i < points.Length; i++,x++)
        {
            if (i == resolution)
            {
                x = 0;
                z += 1;
                v = (z + 0.5f) * step - 1;
            }

            float u = (x + 0.5f) * step - 1;
            points[i].localPosition = f(u, v, time);
            // var point = points[i];
            // Vector3 position = point.localPosition;
            // position.y = f(position.x, position.z, time);
            // point.localPosition = position;
        }
    }
}
