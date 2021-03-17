using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    Image timerBar;
    public float maxTime;
    float timeLeft;

    void Start()
    {
        if (maxTime == 0)
        {
            maxTime = 20f;
        }
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
    }

    void Update()
    {
        if (timeLeft > 0) {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
        } else {
            SceneManager.LoadScene(3);
        }
    }
}
