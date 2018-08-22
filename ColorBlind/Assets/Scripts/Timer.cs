using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	
    //Image of the timer
	Image timerBar;
	
    //Starting time
    public float maxTime = 5f;
    public event System.Action OnTimerOver;

    public GameObject timer;

    //Remaining time
	public  float timeLeft;

    //Time Palyed
    public float timeAlive;

    //GameOver panel
    public GameObject panel;

	// Use this for initialization
	void Start () {
        //setting the screen to false when starting
		panel.SetActive(false);
        //Has the picture of the bar
		timerBar = GetComponent<Image>();
        //Making the full timebar the same as the seconds
		timeLeft= maxTime;
	}

    // Update is called once per frame
    void Update()
    {
        //Records how long the player is alive for
        timeAlive += Time.deltaTime;
        //sets the text of the timer and the 0 rounds the number
        timer.GetComponent<TextMeshProUGUI>().text = timeAlive.ToString("0");
        //if still alive
        if (timeLeft > 0)
        {
            //Reduces time
            timeLeft -= Time.deltaTime;
            //Reduces Bar through the time
            timerBar.fillAmount = timeLeft / maxTime;
        }
        //If we run out of time
        else
        {
            //euns the OnTimeOver method from Game Over class
            if (OnTimerOver != null)
            {
                OnTimerOver();
                //stops the update method from continuing the time when it's meant to stop
                Time.timeScale = 0;
            }
        }
    }

}