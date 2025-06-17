using UnityEngine;
using TMPro;

public class Felling : MonoBehaviour
{
    [SerializeField] private float maxDist;
    [SerializeField] private Animator anim; 
    [SerializeField] TextMeshProUGUI scoreText;
    public static int score = 0;
    [SerializeField] private GameObject pCam;  // 基本カメラ
    [SerializeField] private GameObject fellingCam; // 斧振る時のみカメラ

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScoreText(); // 初期スコアを画面に表示
        fellingCam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Felling");
            pCam.SetActive(false);
            fellingCam.SetActive(true);
            Invoke("Cut", 1.5f);
        }
    }

    // 目の前の距離に応じてその物体を消す
    private void Cut()
    {
        Vector3 pos = transform.position;
        pos.y += 0.5f;
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDist))
        {
            if (hit.collider.gameObject.name == "tree")
            {
                hit.collider.gameObject.SetActive(false);
                AddScore();
            }
            else if (hit.collider.gameObject.name == "bigLeavesTree")
            {
                hit.collider.gameObject.SetActive(false);
                PullScore();
            }
        }
        pCam.SetActive(true);
        fellingCam.SetActive(false);
    }

    // スコアを加算するメソッド
    private void AddScore()
    {
        score++;
        UpdateScoreText(); // スコアを更新
    }

    // スコアを減算するメソッド
    private void PullScore()
    {
        score--;
        UpdateScoreText(); // スコアを更新
    }

    // スコアの表示を更新するメソッド
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    public static int getScore()
    {
        return score;
    }
}
