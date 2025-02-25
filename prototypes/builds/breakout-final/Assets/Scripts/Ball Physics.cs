using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class BallPhysics : MonoBehaviour
{

   public List<GameObject> bricks = new List<GameObject>();

    private Rigidbody rb;

     
  
    //FORCES
    public float gravity = 1f;
    public float airResistance = -0.05f;
    public float bounceFactor = 0.05F;
    public float smallPortionofPaddleSpeed = 0.005F;

     Vector3 newBallVelocity; 
    public int lives = 3;

    


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

   

    void FixedUpdate(){
        rb.AddForce(Physics.gravity * gravity, ForceMode.Acceleration);

    }
     void Update(){
        rb.AddForce(rb.linearVelocity * airResistance, ForceMode.Force);

        if (transform.position.y < -6f){
            Destroy(gameObject);
            lives--;
            Debug.Log("Lives: " + lives);
        }

    }

    private void OnCollisionEnter(Collision collision){
        Rigidbody paddleRb = collision.gameObject.GetComponent<Rigidbody>();
        ContactPoint contact = collision.contacts[0];
        Vector3 ballVelocity = rb.linearVelocity;
       
       

        if(collision.gameObject.CompareTag("Paddle")){
       
           
           Vector3 pVelocity = paddleRb.linearVelocity;

           float paddleSpeedX = pVelocity.x;
           

           newBallVelocity = new Vector3(ballVelocity.x + (paddleSpeedX * smallPortionofPaddleSpeed), Mathf.Abs(ballVelocity.y * bounceFactor ),0);
            // Debug.Log("paddle's velocity (ball pov): " + pVelocity);

        //     Vector3 normal = collision.contacts[0].normal;
        //    Vector3 BallsReflection = Vector3.Reflect(rb.linearVelocity, normal);
        
            float clampedMag = Mathf.Clamp(ballVelocity.magnitude, 0F, 20F);
            rb.linearVelocity = newBallVelocity.normalized * clampedMag;

            // Debug.Log("Ball's Linear Velocity " + rb.linearVelocity);
            // Debug.Log("Ball's Speed:" + ballVelocity.magnitude);
            // Debug.Log("Paddle's Velocity: " + paddleRb.linearVelocity);
            // Debug.Log("Ball's Reflection: " + newBallVelocity);

            // Debug.Log("Ball's Reflection+ Paddle's Velocity: " + (pVelocity + BallsReflection));
            

           

             
        } else{
            newBallVelocity =  Vector3.Reflect(ballVelocity, contact.normal);
             transform.position += contact.normal * 0.01f;
        }

         
         
         if (collision.gameObject.CompareTag("Brick")){
            bricks.Remove(collision.gameObject);
            Debug.Log("Bricks Left" + bricks.Count);
            Destroy(collision.gameObject);

            }   
    }

    
    }


