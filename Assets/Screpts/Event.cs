using UnityEngine;

public class Event : MonoBehaviour
{
    public Shaker shaker;

    // Update is called once per frame
    void Update()
    {
        //Shaker shaker = GetComponent<Shaker>();

        shaker.CShake();
    }
}
