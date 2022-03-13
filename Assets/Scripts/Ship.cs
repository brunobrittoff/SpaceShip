using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    /// <summary>
    /// A ship
    /// </summary>

    // thrust and rotation support
    const float ThrustForce = 5;
    // const float RotateDegreesPerSecond = 150;
    Vector2 thrustXDirection = new Vector2(1, 0);
    Vector2 thrustYDirection = new Vector2(0, 1);
    Rigidbody2D rb2D;

    // Screen wrapper support
    float colliderRadius;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        colliderRadius = GetComponent<CircleCollider2D>().radius;
    }

    // Update is called once per frame
    void Update()
    {
        /* // rotation code
         float rotationInput = Input.GetAxis("Rotate");
         if(rotationInput != 0)
         {
             // calculate rotation amount and apply rotation
             float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;
             if (rotationInput < 0)
             {
                 rotationAmount *= -1;
             }
             transform.Rotate(Vector3.forward, rotationAmount);
             // Changing thrust direction
             // Converts eulerAngles.z (in degrees) to rads
             float zRotation = transform.eulerAngles.z * Mathf.Deg2Rad;
             thrustDirection.x = Mathf.Cos(zRotation);
             thrustDirection.y = Mathf.Sin(zRotation);
         }
        */
       
    }

    /// <summary>
    /// Fixed Update Method
    /// Called every physics step
    /// Adjusts physics (Rigidbody2D) objects
    /// </summary>
    void FixedUpdate()
    {
        float upDownThrust = Input.GetAxis("UpDownThrust");
        if (Input.GetAxis("Thrust") != 0)
        {
            rb2D.AddForce(ThrustForce * thrustXDirection,
                ForceMode2D.Force);
        }
        else if(Input.GetAxis("NegativeThrust") != 0)
        {
            rb2D.AddForce(ThrustForce * -thrustXDirection,
                ForceMode2D.Force);
        }
        else if(upDownThrust != 0)
        {
            if(upDownThrust > 0)
            {
                // If positive, the ship goes down
                rb2D.AddForce(ThrustForce * thrustYDirection,
                ForceMode2D.Force);
            }
            else
            {
                // if negative, the ship goes up
                rb2D.AddForce(ThrustForce * -thrustYDirection,
                ForceMode2D.Force);
            }
        }
    }

    /// <summary>
    /// Wrap the Ship if became invisible.
    /// </summary>
    void OnBecameInvisible()
    {
      
    }

}
