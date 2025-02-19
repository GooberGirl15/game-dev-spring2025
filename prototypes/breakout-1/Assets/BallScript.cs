using System.Numerics;
using Mono.Cecil.Cil;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField]

    Rigidbody rb;
    
     bool wasPaddleLastHit = false;
     int charge = 0;

    [SerializeField] GameObject paddles;
    Paddle_Script paddle_Script;
   
   
    UnityEngine.Vector3 initVelocity;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
       
        paddle_Script = paddles.GetComponent<Paddle_Script>();
        
        initVelocity = new UnityEngine.Vector3(5,-5,0);
        rb.linearVelocity = initVelocity;
        
    }
    

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Brick")){
            Destroy(collision.gameObject);
            wasPaddleLastHit = false;
            // Debug.Log(wasPaddleLastHit);
            DecreaseVelocity();
        }

        if (collision.gameObject.CompareTag("Paddle")){
            wasPaddleLastHit = true;
            Debug.Log(wasPaddleLastHit);
            BallDirection();
            Debug.Log(rb.linearVelocity);
            
        }

         if (collision.gameObject.CompareTag("Wall")){
            wasPaddleLastHit = false;
            // Debug.Log(wasPaddleLastHit);
        }

        if (collision.gameObject.CompareTag("Floor")){
            if (wasPaddleLastHit == true){
                charge += 1;
                Debug.Log("Charge Amount:" + charge);
                IncreaseVelocity();
            }
            if (wasPaddleLastHit == false){
                charge = 0;
                // DecreaseVelocity();
            }

        }
       

    }

    void IncreaseVelocity(){
        rb.linearVelocity = rb.linearVelocity.magnitude * 1.1f * rb.linearVelocity.normalized;
    }

    void DecreaseVelocity(){
        rb.linearVelocity = rb.linearVelocity.magnitude * 0.5f * rb.linearVelocity.normalized;
        
    }

    void BallDirection(){
        float speed = paddle_Script.getPaddleSpeed();
        Debug.Log("Ball Direction Speed: " + speed);

        UnityEngine.Vector3 pSpeed = rb.linearVelocity;
        // float speed = ref_Paddle_Script.getPaddleSpeed();
        pSpeed.x = speed;
        if (speed > 0){
            rb.linearVelocity = rb.linearVelocity + pSpeed;
            Debug.Log("paddle speed is:" + pSpeed);
        }

    }
}

    

