using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf; //use static之后 不需要加类名 直接使用成员

public static class FunctionLibrary
{
    public delegate Vector3 Function(float x, float z, float t);

    public enum FunctionName
    {
        Wave,
        MultiWave,
        Ripple
    };

    private static Function[] functions = {Wave, MultiWave, Ripple};

    public static Function GetFunction(FunctionName name)
    {
        return functions[(int) name];
    }

    public static Vector3 Wave(float u, float v, float t)
    {
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (u + 0.5f * t));
        p.y += 0.5f * Sin(2f * PI * (v + t));
        p.y += Sin(PI * (u + v + 0.25f * t));
        p.y *= 1f / 2.5f;
        p.z = v;
        return p;
    }

    public static Vector3 MultiWave(float x, float z, float t)
    {
        float y = Sin(PI * (x + 0.5f * t));
        y += 0.5f * Sin(2f * PI * (z + t));
        y += Sin(PI * (x + z + 0.25f * t));
        return Vector3.back;
        //return y * (1f / 2.5f);
    }

    public static Vector3 Ripple(float u, float v, float t)
    {
        float d = Sqrt(u * u + v * v);
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (4f * d - t));
        p.y /= 1f + 10f * d;
        p.z = v;
        return p;
    }
}
