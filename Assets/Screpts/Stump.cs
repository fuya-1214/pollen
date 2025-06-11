using UnityEngine;

public class Stump : MonoBehaviour
{
    [SerializeField] private GameObject stump;
    public void OnDisable()
    {
        Debug.Log("a");
        stump.SetActive(true);
    }
}
