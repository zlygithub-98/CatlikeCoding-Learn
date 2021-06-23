﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField] private Transform pointPrefab;

    //必须在10-100之间
    [SerializeField, Range(10, 100)] private int resolution = 10;

    Transform[] points;

    void Awake()
    {
        float step = 2f / resolution;
        Vector3 position = Vector3.zero;
        var scale = Vector3.one * step;
        points = new Transform[resolution];
        for (int i = 0; i < points.Length; i++)
        {
            //如果我们连续多次分配相同的内容，我们可以将这些分配链接在一起，因为分配表达式的结果就是分配的结果
            Transform point = points[i] = Instantiate(pointPrefab);
            position.x = (i + 0.5f) * step - 1f;
            point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform, false);
        }
    }

    private void Update()
    {
        float time = Time.time;
        for (int i = 0; i < points.Length; i++)
        {
            var p = points[i];
            Vector3 pos = p.localPosition;
            pos.y = Mathf.Sin(Mathf.PI * pos.x + time);
            p.localPosition = pos;
        }
    }
}
