using UnityEditor;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private GameObject ItemObject;
    [SerializeField] private Stump stump;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ItemDrop()
    {
        Debug.Log("a");
        if (stump.GetItemName() == "切り株")
        {
            Instantiate(ItemObject, new Vector3(transform.position.x, 101.5519f, transform.position.z) , Quaternion.identity);
        }
    }
}
