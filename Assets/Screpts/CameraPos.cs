using Unity.VisualScripting;
using UnityEngine;

public class CameraPos : MonoBehaviour
{
    [SerializeField] private Transform cameraPos;

    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPos.position;
    }
}
