using UnityEngine;

public class Ball_Script : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed = 10f;

    public float addedForce;

    bool wasPaddleLastHit = false;

    int charge = 0;

    public float chargePercentage = 0.5F;

    Vector2 lastVelocity;

    public float boostDuration = 3F;

    

    // private Vector2 currentVelocity;

    UnityEngine.Vector2 velocity;
    Vector2 force2;


    [SerializeField] GameObject paddle;
    AltPaddleScript paddleScript;

   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    paddleScript = paddle.GetComponent<AltPaddleScript>();
      Vector2 force = Vector2.zero;
      force.x = 0;
      force.y = -1f;

      velocity = force.normalized * this.speed;

      this.rb.AddForce(velocity);   

      float addedForce = Random.Range(5F, 10F);   
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    //   Debug.Log("Ball's Linear Velocity: " + rb.linearVelocity);   

      

    }
    void Update(){
        Debug.DrawRay(velocity,rb.linearVelocity,Color.red);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Brick")){
            Destroy(collision.gameObject);
            wasPaddleLastHit = false;

        } if (collision.gameObject.CompareTag("Paddle")){
            wasPaddleLastHit = true;
            Vector2 force2 = Vector2.zero;

            int direction = paddleScript.GetPaddleDirection();

            // Debug.Log(direction);
            if (direction == 1){
                force2.x = addedForce;
                force2.y = addedForce;
                
            } else if (direction == -1){
                force2.x = -addedForce;
                force2.y = -addedForce;
               
            }
            rb.linearVelocity = rb.linearVelocity + force2;
            // rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity,50F);
            
            

        } if (collision.gameObject.CompareTag("Wall")){
            wasPaddleLastHit = false;
        } if (collision.gameObject.CompareTag("Floor")){
            if (wasPaddleLastHit == true){
                Debug.Log("Linear Velocity: " + rb.linearVelocity);
                charge += 1;
                float chargeAmt = charge * chargePercentage;
                Debug.Log("Charge Amount: " + chargeAmt);
        
            }
            if (wasPaddleLastHit == false){
                charge = 0;
            }
            Debug.Log("Charge: " + charge);
            
        }
    }

    
}

