using System.Runtime.CompilerServices;
using UnityEngine;

[SerializeField]
[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
public class Stump : MonoBehaviour
{
    public enum Type
    {
        stump // 切り株
    }
    [SerializeField] private Type itemType = Type.stump;
    [SerializeField] private string ItemName = ""; // アイテムの名前
    [SerializeField] private string information = ""; // アイテムの情報
    [SerializeField] private int amount = 0;

    public Type GetItemType()
    {
        return itemType;
    }

    public string GetItemName()
    {
        return ItemName;
    }

    public string GetInformation()
    {
        return information;
    }

    public int GetAmount()
    {
        return amount;
    }

}
