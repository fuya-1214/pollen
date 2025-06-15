using UnityEngine;

public class Tears : MonoBehaviour // 画面をにじませる
{
    public bool tear = true;
    private bool tear2 = false;
    [SerializeField] private GameObject obscure;
    [SerializeField] private GameObject Red;
    [SerializeField] private Shaker shaker;

    public void EventSneeze()
    {
        if (tear)
        {
            Invoke("Tear1", Random.Range(1.0f, 10.0f));
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
        shaker.vib = false;
        ColorOn();
        Invoke("Check", 3.0f);
    }

    private void Tear2()
    {
        if (tear2 == true)
        {
            obscure.SetActive(true);

            Invoke("AllOff", 5.0f);
        }
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
        shaker.vib = true;
    }
}
