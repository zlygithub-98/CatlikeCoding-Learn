using System;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] Transform hoursPivot = default, minutesPivot, secondsPivot;
    const float hoursToDegrees = -30f, minutesToDegrees = -6f, secondsToDegrees = -6f;

    void Awake()
    {
        DateTime time = DateTime.Now;
        hoursPivot.localRotation =
            Quaternion.Euler(0f, 0f, hoursToDegrees * time.Hour);
        minutesPivot.localRotation =
            Quaternion.Euler(0f, 0f, minutesToDegrees * time.Minute);
        secondsPivot.localRotation =
            Quaternion.Euler(0f, 0f, secondsToDegrees * time.Second);
    }

    void Update()
    {
        TimeSpan time = DateTime.Now.TimeOfDay;
        hoursPivot.localRotation =
            Quaternion.Euler(0f, 0f, (float) (hoursToDegrees * time.TotalHours));
        minutesPivot.localRotation =
            Quaternion.Euler(0f, 0f, (float) (minutesToDegrees * time.TotalMinutes));
        secondsPivot.localRotation =
            Quaternion.Euler(0f, 0f, (float) (secondsToDegrees * time.TotalSeconds));
    }
}
