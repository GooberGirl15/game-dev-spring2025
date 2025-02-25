using Unity.VisualScripting;
using UnityEngine;

public class NewPaddleScript : MonoBehaviour
{

    public float moveAmt = 0.20F;


    private Rigidbody paddleRb;

    private Vector3 movePos;

    

    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       paddleRb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.65f,8.65f),transform.position.y,0);
        movePos = Vector3.zero;
         if (Input.GetKey(KeyCode.LeftArrow)){
            movePos = Vector3.left;
         }

        if (Input.GetKey(KeyCode.RightArrow)){
           movePos = Vector3.right;
    }
    
    
    
    
}

    void FixedUpdate()
    {
        paddleRb.MovePosition(paddleRb.position + movePos * moveAmt * Time.fixedDeltaTime);
    }

    void OnCollisionEnter(Collision collision){
if (collision.gameObject.CompareTag("Ball")){
    // Debug.Log("Paddle's velocity(paddle pov): " + paddleVelocity);

}


}


   
}
