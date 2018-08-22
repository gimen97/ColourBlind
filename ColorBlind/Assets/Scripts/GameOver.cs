using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    //Shows how many seconds are left text
    public Text secondsSurvived;
    //Boolean to check if the game is over
    bool gameOver;
    //Int to keep the highScore
    int highscore;
    //GameOver panel
    public GameObject panel;
     

	// Use this for initialization
	void Start () {

        //Runs the start method of the Timer
        FindObjectOfType<Timer>().OnTimerOver += OnGameOver;
	}
	
	// Update is called once per frame
	void Update () {
        //if the game ends
        if (gameOver == true)
        {
            //When user presses spacebar
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Resumes the update method
                Time.timeScale = 1;
                //Reloads scene
                SceneManager.LoadScene(0);
            }
        }
	}

    public void OnGameOver(){
        //Sets the panel active
        panel.SetActive(true);
        //Updates the highscore
        secondsSurvived.text = Time.timeSinceLevelLoad.ToString("0");

        //Stops playing the main song
        AudioManager.instance.Stop("Game");

        //sets the gameover to true
        gameOver = true;
    }
}