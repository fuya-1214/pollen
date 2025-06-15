using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shaker : MonoBehaviour // カメラを揺らす
{
    public bool vib = true;
    private bool shake2 = false;
    private int counter;
    private int countMax = 10;
    [SerializeField] private Animator anim; 
    [SerializeField] private Tears tears;

    public void EventShake()
    {
        if (vib)
        {
            Invoke("Shake1", Random.Range(1.0f, 10.0f));
        }
        else
        {
            Invoke("Cancel", 0.1f);
            Shake2();
        }
    }

    private void Check()
    {
        shake2 = true;
    }

    private void Cancel()
    {
        CancelInvoke("Shake1");
    }

    private void Shake1()
    {
        vib = false;
        tears.tear = false;
        anim.SetTrigger("Sneeze");
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
                    tears.tear = true;
                }
            }
        }
    }
}
