using System.ComponentModel;
using UnityEngine;

public class Event : MonoBehaviour
{
    [SerializeField] private Shaker shaker;
    [SerializeField] private Tears tears;
    private float nextEventTime;
    public bool stop = false;
    public bool ah = true;

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            Debug.Log("0");
            ScheduleNextEvent();
            stop = true;
        }

        if (Time.time >= nextEventTime)
        {
            if (ah)
            {
                TriggerRandomEvent();
            }
            //ScheduleNextEvent();
        }

        shaker.Shake2();
        
    }

    private void ScheduleNextEvent()
    {
        nextEventTime = Time.time + Random.Range(3f, 5f); // 1～5秒後に次のイベントをスケジュール
    }

    private void TriggerRandomEvent()
    {
        ah = false;
        int randomValue = Random.Range(1, 3);


        if (randomValue == 1) EventShaker(); 
        if (randomValue == 2) EventTears();
    }

    private void EventShaker()
    {
        shaker.EventShake(); 
    }

    private void EventTears()
    {
        tears.EventTears();
    }
}
