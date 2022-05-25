using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSpeedController : MonoBehaviour
{
    /* Game pause, play */
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

    public GameObject ballObj;
    private GameObject oldBallObj;
    private Vector3 ballStartPos = new Vector3(-0.04f, 1.88f, -5.49f);
    private Vector3 ballStartRot = new Vector3(0f, 0f, 0f);

    void Start()
    {
        pauseButtonText.text = "play";
        slowButtonText.text = "slow";
        turnButtonText.text = "no spin";
    }

    /*
        Play/Reset the simulation the simulation
    */
    public void onPauseButtonClick()
    {
        paused = !paused;

        if (paused)
        {
            oldBallObj = ballObj;
            ballObj = Instantiate(ballObj, ballStartPos, Quaternion.Euler(ballStartRot));
            Destroy(oldBallObj);
            pauseButtonText.text = "play";
        }
        else
        {
            Time.timeScale = currentTimeScale;
            pauseButtonText.text = "reset";
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
            resetScene();
        }
        else
        {
            currentTimeScale = 1f;
            slowButtonText.text = "slow";
            resetScene();
        }
    }

    public void onTurnButtonClick()
    {
        turn += 1;
        turn = turn % 3;

        if(turn == 0){
            turnFactor = 0;
            turnButtonText.text = "no spin";
            resetScene();
        } else if(turn == 1){
            turnFactor = 1;
            turnButtonText.text = "Right Off Spin";
            resetScene();
        } else {
            turnFactor = -1;
            turnButtonText.text = "Left Off Spin";
            resetScene();
        }

        Debug.Log("GSC turn factor : " + turnFactor);
    }

    /*
    * Resests the scene
    */
    public void resetScene()
    {
        paused = false;
        onPauseButtonClick();
    }

}
