using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallLocationController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    private float movX;
    private float movY;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue movementValue){
        Vector2 moveVector = movementValue.Get<Vector2>();
        movX = moveVector.x;
        movY = moveVector.y;
    }
    private float movementSpeed = 0.01f;

    void Update()
    {
        //get the Input from Horizontal axis
        //update the position
        rb.transform.position = transform.position + new Vector3(0,movY * movementSpeed , movX * movementSpeed);

        //output to log the position change
    }

    // void FixedUpdate(){
    //     Vector3 movement = new Vector3(movX, 0.0f, movY);
    //     rb.AddForce(movement);
    
    // }

}
