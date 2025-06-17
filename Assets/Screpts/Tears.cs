using UnityEngine;

public class Tears : MonoBehaviour // 画面をにじませる
{
    private bool tear = true;
    public bool tear2 = false;
    [SerializeField] private GameObject obscure;
    [SerializeField] private GameObject Red;
    [SerializeField] private Event @event;

    public void EventTears()
    {
        if (tear)
        {
            Tear1();
            //Invoke("Tear1", Random.Range(1.0f, 20.0f));
        }
        else
        {
            Invoke("Cancel", 0.2f);
            Tear2();
        }
    }

    private void Check()
    {
        tear2 = true;
    }

    private void Cancel()
    {
        CancelInvoke("Tear1");
    }

    private void Tear1()
    {
        tear = false;
        ColorOn();
        Invoke("Tear2", 3.0f);
    }

    private void Tear2()
    {
            obscure.SetActive(true);

            Invoke("AllOff", 5.0f);
    }
    private void ColorOn() // 画面を赤くする
    {
        Red.SetActive(true);
    }

    private void ColorOff() // 画面を戻す
    {
        Red.SetActive(false);
    }

    private void AllOff()
    {
        tear = true;
        tear2 = false;
        ColorOff();
        obscure.SetActive(false);
        @event.stop = false;
        @event.ah = true;
    }
}
