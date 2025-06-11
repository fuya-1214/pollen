using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shaker : MonoBehaviour // カメラを揺らす
{
    private bool vib = true;
    private bool shake2 = false;
    private int counter;
    private int countMax = 10;

    public void CShake()
    {
        if (vib)
        {
            Invoke("Shake1", Random.Range(1.0f, 10.0f));
        }
        else
        {
            Invoke("Cancel", 1);
            Shake2();
        }
    }

    private void Check()
    {
        shake2 = true;
        Debug.Log("オン");
    }

    private void Cancel()
    {
        CancelInvoke("Shake1");
    }

    private void Shake1()
    {
        vib = false;
        Debug.Log("起こる");
        var impulseSource = GetComponent<CinemachineImpulseSource>();
        impulseSource.GenerateImpulse();
        Invoke("Check", 5.0f);
    }

    private void Shake2()
    {
        if (shake2 == true)
        {
            Move move = GameObject.FindWithTag("Player").GetComponent<Move>();
            move.move = false;
            var impulseSource = GetComponent<CinemachineImpulseSource>();
            impulseSource.GenerateImpulse();

            if (Input.GetKeyDown(KeyCode.R))
            {
                counter++;
                if (counter >= countMax)
                {
                    vib = true;
                    shake2 = false;
                    move.move = true;
                }
            }
        }
    }
}
