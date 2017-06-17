using System.Collections;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public static Clock main;

    void Awake()
    {
        if (main == null)
            main = this;
    }

    public void scheduleTimeAction(float interval, TimeAction action, object data, int times = 1)
    {
        StartCoroutine(TimeActionPerformer(interval, times, action, data));
    }

    IEnumerator TimeActionPerformer(float seconds, int times, TimeAction action, object data)
    {
        int _times = times;
        if (_times == 0)
            _times = -1;
        while (_times != 0)
        {
            yield return new WaitForSeconds(seconds);
            action(data);
            if (_times > 0)
                _times--;
        }
    }

}
public delegate void TimeAction(object data);