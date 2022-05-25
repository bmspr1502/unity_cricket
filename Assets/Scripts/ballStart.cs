using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ballStart : MonoBehaviour
{

    private Rigidbody r;

    /*
    *   Direction and force of ball throw.
    */
    public Vector3 throwDirection = new Vector3(0, 0, 0);

    // public float spinTorque = 5000;
    
    /*
    * Wind direction and speed
    */
    public Vector3 windDirection = new Vector3(0, 0, 0);
    
    // public float airSpeedDivider = 1f;
    // protected GameSpeedController speedController;

    public GameSpeedController GSC;

    // Start is called before the first frame update
    void Start()
    {
        // start with everything turned off
        Time.timeScale = 0;

        // get reference to the ball's rigid body
        r = GetComponent<Rigidbody>();
        r.maxAngularVelocity = 100000; // set maximum spin rate for ball

        // throwing the ball for the first time
        r.AddForce(throwDirection);

        // r.AddTorque(1000 * spinTorque * GSC.turnFactor, 0, 0);
    }

    void FixedUpdate()
    {
        /* Applying Drag Force on the ball*/
        Vector3 ballVelocity = r.velocity;
        Vector3 dragVector = ballVelocity + windDirection;
        dragVector = Vector3.Scale(dragVector, dragVector);
        dragVector = Vector3.Scale(dragVector, windDirection.normalized);

        // Debug.Log("Ball velocity : " + ballVelocity);
        // Debug.Log("Drag : " + dragVector * 0.01f);
        
        r.AddForce(dragVector * 0.01f);

        /* Handle swing mechanics of the ball */
    }
}
