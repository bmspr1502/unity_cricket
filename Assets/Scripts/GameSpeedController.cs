using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameSpeedController : MonoBehaviour
{
    private bool paused = true;
    public Text pauseButtonText;

    public Text slowButtonText;
    private bool slowed = false;
    public float slowFactor = 0.3f;

    private float currentTimeScale = 1f;

    public Text turnButtonText;
    private int turn = 0;

    // private bool rightTurn = true;
    // private bool turn = true;
    public int turnFactor = 0;

    void Start()
    {
        pauseButtonText.text = "play";
        slowButtonText.text = "slow";
        turnButtonText.text = "no spin";
    }

    /*
    Play/Pause the simulation
    */
    public void onPauseButtonClick()
    {
        paused = !paused;

        if (paused)
        {
            Time.timeScale = 0;
            pauseButtonText.text = "Play";
        }
        else
        {
            Time.timeScale = currentTimeScale;
            pauseButtonText.text = "Pause";
        }
    }

    /*
    Controls the speed of the simulation
    */
    public void onSlowButtonClick()
    {
        slowed = !slowed;

        if (slowed)
        {
            currentTimeScale = slowFactor;
            slowButtonText.text = "normal";
        }
        else
        {
            currentTimeScale = 1f;
            slowButtonText.text = "slow";
        }
    }

    /*
    * Resests the scene
    */
    public void resetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void onTurnButtonClick()
    {
        turn += 1;
        turn = turn % 3;

        Debug.Log(turn);

        if(turn == 0){
            turnFactor = 0;
            turnButtonText.text = "no spin";
        } else if(turn == 1){
            turnFactor = 1;
            turnButtonText.text = "Right Off Spin";
        } else {
            turnFactor = -1;
            turnButtonText.text = "Left Off Spin";
        }
    }
}
