using System;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] Transform hoursPivot, minutesPivot, secondsPivot;
    const float hoursToDegrees = -30f, minutesToDegrees = -6f, secondsToDegrees = -6f;

    private void Start()
    {
        Debug.Log("Hour默认(整数的)数据：" + DateTime.Now.Hour);
        Debug.Log("TotalHours小数数据：" + DateTime.Now.TimeOfDay.TotalHours);
    }

    void Update()
    {
        TimeSpan time = DateTime.Now.TimeOfDay;
        hoursPivot.localRotation = Quaternion.Euler(0f, 0f, (float) (hoursToDegrees * time.TotalHours));
        minutesPivot.localRotation = Quaternion.Euler(0f, 0f, (float) (minutesToDegrees * time.TotalMinutes));
        secondsPivot.localRotation = Quaternion.Euler(0f, 0f, (float) (secondsToDegrees * time.TotalSeconds));
    }
}
