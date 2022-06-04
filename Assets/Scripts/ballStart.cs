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

    public const float spinTorque = 1f;
    
    /*
    * Wind direction and speed
    */
    public Vector3 windDirection = new Vector3(0, 0, 0);

    
    // public float airSpeedDivider = 1f;
    // protected GameSpeedController speedController;

    public GameSpeedController GSC;

    private List<Vector3> ballPositions;

    // Start is called before the first frame update
    void Start()
    {
        // start with everything turned off
        Time.timeScale = 0;

        // get reference to the ball's rigid body
        r = GetComponent<Rigidbody>();
        r.maxAngularVelocity = 100000; // set maximum spin rate for ball

        // throwing the ball for the first time
        // Debug.Log("Ball thinks release speed is: " + GSC.releaseSpeed + "km/h");
        // Debug.Log("Ball thinks release angle is: " + GSC.releaseAngle +" deg");
        r.AddForce(throwDirection + new Vector3(0, GSC.releaseAngle, GSC.releaseSpeed * 1.1f));
        
        // Debug.Log("Ball thinks spin is : " + (spinTorque *  GSC.turnValue));
        r.AddTorque(0 ,0, spinTorque * -GSC.turnValue);

        // Debug.Log("Ball thinks air speed is : " + GSC.airSpeed + "km/h" );
        windDirection = new Vector3(GSC.airSpeed / 5, 0, 0);

        ballPositions = new List<Vector3>();
        
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
        
        // get wind speed along z-axis
        float forwardWindSpeed = GSC.airSpeed;
        Debug.Log("wind : " + forwardWindSpeed);
        

        // get ball speed along z-axis
        float forwardSpeed = r.velocity.z;
        Debug.Log("Ball is moving forward at " + forwardSpeed);

        // get seam angle
        float seamAngle = GSC.seamAngle;
        Debug.Log("Seam angle : " + GSC.seamAngle);

        // get roughness
        Vector2 roughness = GSC.roughness;
        Debug.Log("ball roughness : " + roughness);

        // compute relative wind speed for the ball
        float overallRelativeWindSpeed = Mathf.Abs(forwardWindSpeed - forwardSpeed);
        Debug.Log("relative wind speed : " + overallRelativeWindSpeed);

        // compute a force for the left side of the ball
        float leftSpeed = (overallRelativeWindSpeed * 0.4f) * (roughness.x * 3f) - seamAngle * 0.7f;
        leftSpeed = Mathf.Clamp(leftSpeed, 0, leftSpeed);
        Debug.Log("left speed : " + leftSpeed);


        // compute a force for the right side of the ball
        float rightSpeed = (overallRelativeWindSpeed * 0.4f) * (roughness.y * 3f) + seamAngle * 0.7f ;
        rightSpeed = Mathf.Clamp(rightSpeed, 0, rightSpeed);
        Debug.Log("right speed : " + rightSpeed);

        float differential = rightSpeed - leftSpeed;
        Debug.Log("Speed differential : " + differential);

        r.AddForce(new Vector3(differential * 0.002f, 0, 0));

        ballPositions.Add(r.worldCenterOfMass);

        Color red = Color.red;
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetColors(red, red);
        lineRenderer.SetWidth(0.02F, 0.02F);

        //Change how mant points based on the mount of positions is the List
        lineRenderer.SetVertexCount(ballPositions.Count);

        for (int i = 0; i < ballPositions.Count; i++ )
        {
            //Change the postion of the lines
            lineRenderer.SetPosition(i, ballPositions[i]);
        }
    }
}
