using UnityEngine;

public class Stump : MonoBehaviour
{
    [SerializeField] private GameObject stump;
    public void OnDisable()
    {
        stump.SetActive(true);
    }
}
