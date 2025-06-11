using UnityEngine;

public class TreeBase : MonoBehaviour
{
    private int hp = 10;

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(this);
        }
    }

}
