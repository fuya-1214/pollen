using UnityEngine;
using TMPro;

public class Felling : MonoBehaviour
{
    [SerializeField] private float maxDist;
    [SerializeField] TextMeshProUGUI scoreText;
    public static int score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScoreText(); // 初期スコアを画面に表示
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.y += 0.5f;
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
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
        }
    }

    // スコアを加算するメソッド
    public void AddScore()
    {
        score++;
        UpdateScoreText(); // スコアを更新
    }

    // スコアを減算するメソッド
    public void PullScore()
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
