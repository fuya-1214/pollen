using TMPro;
using UnityEngine;

public class TotalScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScoreText;
    private int score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = Felling.getScore();

        ScoreText.text = string.Format("Score:{0}", score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
