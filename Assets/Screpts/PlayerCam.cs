using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] private float sensX;
    [SerializeField] private float sensY;

    [SerializeField] private Transform orientation;
    [SerializeField] private Transform CamHolder;

    [SerializeField] private float viewAngle;

    private float xRotation;
    private float yRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //　マウスポインターを真ん中に固定し見えなくする
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            // マウスの入力を取得
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

            yRotation += mouseX;

            xRotation -= mouseY;

            Rotate(mouseX, mouseY, viewAngle);
            // カメラとプレイヤーの向きを動かす
            CamHolder.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }

    void Rotate(float mouseX,float mouseY,float limit)
    {
        float maxLimit = limit, minLimit = 360 - maxLimit;
        //X軸回転
        var localAngle = transform.localEulerAngles;
        localAngle.x += mouseY;
        if (localAngle.x > maxLimit && localAngle.x < 180)
            localAngle.x = maxLimit;
        if (localAngle.x < minLimit && localAngle.x > 180)
            localAngle.x = minLimit;
        transform.localEulerAngles = localAngle;
        //Y軸回転
        var angle = transform.eulerAngles;
        angle.y += mouseX;
        transform.eulerAngles = angle;
    }

}
