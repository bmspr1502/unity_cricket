using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ballStart : MonoBehaviour
{

    protected Rigidbody r;
    public float throwForce = 600;
    public float spinTorque = 5000;
    public float airSpeed = 1;
    // public float airSpeedDivider = 1f;
    // protected GameSpeedController speedController;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;


        r = GetComponent<Rigidbody>();
        // speedController = GetComponent<GameSpeedController>();

        r.maxAngularVelocity = 100000;

        // throwing the ball for the first time
        r.AddForce(new Vector3(-1, 0, -0.1f) * throwForce);
        // r.AddForce(Vector3.forward * airSpeed);

        r.AddTorque(1000 * spinTorque, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        r.AddForce(new Vector3(0,0,1f));
    }
}
