using UnityEngine;

public class LightRotate : MonoBehaviour
{
    public float dayDuration = 10f; // １日の長さ(秒)
    private float time;
    
    // Update is called once per frame
    void Update()
    {
        time = Time.deltaTime / dayDuration;
        transform.Rotate(new Vector3(0, 130, 0) * time);
    }
}

public class s :MonoBehaviour
{
    public Vector3 targetEulerAngles = new Vector3(0, 90, 0); // 目標角度
    public float duration = 60f; // 回転にかける時間（秒）

    private Quaternion startRotation;
    private Quaternion targetRotation;
    private float elapsedTime = 0f;

    void aa()
    {
        // 初期回転と目標回転を設定
        startRotation = transform.rotation;
        targetRotation = Quaternion.Euler(targetEulerAngles);
    }

    void ee()
    {
        if (elapsedTime < duration)
        {
            // 経過時間を更新
            elapsedTime += Time.deltaTime;

            // 回転を補間
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, elapsedTime / duration);
        }
    }
}
