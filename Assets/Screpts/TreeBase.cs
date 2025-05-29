using UnityEngine;

public class TreeBase : MonoBehaviour
{
    private int hp = 10;
    [SerializeField] private ItemManager itemManager;

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(this);
        }
    }

    public void DropStump()
    {
        itemManager.ItemDrop();
    }
}
