using UnityEngine;

public class Event : MonoBehaviour
{
    [SerializeField] private Shaker shaker;
    [SerializeField] private Tears tears;

    // Update is called once per frame
    void Update()
    {
        tears.EventSneeze();
        shaker.EventShake();
    }
}
