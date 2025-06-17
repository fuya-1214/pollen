using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shaker : MonoBehaviour // カメラを揺らす
{
    private bool vib = true;
    private bool shake2 = false;
    private int counter;
    private int countMax = 10;
    [SerializeField] private Animator anim; 
    [SerializeField] private Event @event;

    public void EventShake()
    {
        if (vib)
        {
            Shake1();
            //Invoke("Shake1", Random.Range(2.0f, 10.0f));
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
        anim.SetTrigger("Sneeze");
        var impulseSource = GetComponent<CinemachineImpulseSource>();
        impulseSource.GenerateImpulse();
        Invoke("Check", 5.0f);
    }

    public void Shake2()
    {
        if (shake2)
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
                    @event.stop = false;
                    @event.ah = true;
                }
            }
        }
    }
}
