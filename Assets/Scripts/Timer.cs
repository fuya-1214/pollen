using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeTexts;
    [SerializeField] private float totalTime = 5;
    private int retime;

    void Update()
    {
        totalTime -= Time.deltaTime;
        retime = (int)totalTime;
        timeTexts.text = retime.ToString();
        if (retime == 0)
        {
            SceneManager.LoadScene("ScoreResult");
        }
    }
}