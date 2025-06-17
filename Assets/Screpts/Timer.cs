using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeTexts;
    [SerializeField] private float totalTime = 5; // 制限時間
    private int retime;

    void Update()
    {
        totalTime -= Time.deltaTime;
        var span = new TimeSpan(0, 0, (int)totalTime);
        timeTexts.text = span.ToString(@"mm\:ss");

        if (totalTime <= 0)
        {
            SceneManager.LoadScene("ScoreResult");
        }
    }
}