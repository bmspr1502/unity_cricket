using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeliveryTypeController : MonoBehaviour
{
    public Text turnButtonText;
    private bool rightTurn = true;
    public int turnFactor = 1;

    void Start() {
        turnButtonText.text = "Right Off Spin";
    }
    
    public void onTurnButtonClick()
    {
        rightTurn = !rightTurn;

        Debug.Log("Hello");
        if (rightTurn)
        {
            turnFactor = 1;
            turnButtonText.text = "Right Off Spin";
        }
        else
        {
            turnFactor = -1;
            turnButtonText.text = "Left Off Spin";
        }
    }

}