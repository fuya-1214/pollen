using UnityEngine;
using TMPro;

public class Felling : MonoBehaviour
{
    [SerializeField] float maxDist;
    [SerializeField] TextMeshProUGUI scoreText;
    public static int score = 0;
    [SerializeField] private TreeBase treeBase;

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
                if (hit.collider.gameObject.name == "tree(Clone)")
                {
                    Destroy(hit.collider.gameObject);
                    AddScore();
                    treeBase.DropStump();
                }
                else if (hit.collider.gameObject.name == "bigLeavesTree(Clone)")
                {
                    Destroy(hit.collider.gameObject);
                    PullScore();
                    treeBase.DropStump();
                }
                else if (hit.collider.gameObject.name == "tree")
                {
                    Destroy(hit.collider.gameObject);
                    treeBase.DropStump();
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
