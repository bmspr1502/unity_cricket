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
    
    void Start(){
        pauseButtonText.text = "Play";
        slowButtonText.text = "slow";
    }

    /*
    Play/Pause the simulation
    */
    public void onPauseButtonClick(){
        paused = !paused;

        if(paused){
            Time.timeScale = 0;
            pauseButtonText.text = "Play";
        } else {
            Time.timeScale = currentTimeScale;
            pauseButtonText.text = "Pause";
        }   
    }

    /*
    Controls the speed of the simulation
    */
    public void onSlowButtonClick(){
        slowed = !slowed;

        if(slowed){
            currentTimeScale = slowFactor;
            slowButtonText.text = "normal";
        } else {
            currentTimeScale = 1f;
            slowButtonText.text = "slow";
        }
    }

    /*
    * Resests the scene
    */
    public void resetScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }   
}
