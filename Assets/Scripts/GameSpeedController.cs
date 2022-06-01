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
    // private int turn = 0;
    public float turnValue = 0f;

    // private bool rightTurn = true;
    // private bool turn = true;
    public int turnFactor = 0;

    public GameObject ballObj;
    private GameObject oldBallObj;
    private Vector3 ballStartPos = new Vector3(-0.04f, 1.68f, -5.49f);
    public Vector3 ballStartRot = new Vector3(0f, 0f, 0f);
    public float releaseSpeed = 80f;
    public float releaseAngle = 0f;
    public float airSpeed = 0f;
    public float seamAngle = 0f;
    public Vector2 roughness = new Vector2(0, 0);

    private const float ballDia = 0.43f;

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
            ballObj.GetComponent<Rigidbody>().isKinematic = false;
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

    public void onSpinSliderChange(float value){
        turnValue = value;
        resetScene();
    }

    public void onReleaseSpeedSliderChange(float value){
        releaseSpeed = value;
        resetScene();
    }

    public void onReleaseAngleSliderChange(float value){
        releaseAngle = value;
        resetScene();
    }

    public void onSeamAngleSliderChange(float value){
        ballStartRot.y = value;
        seamAngle = value;
        resetScene();
    }

    public void onAirSpeedSliderChange(float value){
        airSpeed = value;
        resetScene();
    }

    public void onRoughnessSliderChange(float value){
        if(value < 0){
            roughness.x = -value;
            roughness.y = 0;
        } else if(value > 0){
            roughness.x = 0;
            roughness.y = value;
        } else {
            roughness.x = 0;
            roughness.y = 0;
        }
        resetScene();
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
