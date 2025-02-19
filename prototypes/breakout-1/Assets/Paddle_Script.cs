using System.Globalization;
using UnityEngine;

public class Paddle_Script : MonoBehaviour
{
   Vector3 lastPosition;
   public float paddleSpeed;
   public float paddleDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      lastPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
    // paddleSpeed declaration 
      paddleSpeed = transform.position.x - lastPosition.x;
      Debug.Log("Last Position is:" + lastPosition.x);
      Debug.Log("Speed of Paddle: "+ paddleSpeed);

     // if left is pressed, move left
     if (Input.GetKey(KeyCode.LeftArrow)){
        Vector3 newPosition = transform.position;
        float pos = 0.20F;
        newPosition.x -= pos;
        transform.position = newPosition;
     }

     //if right is pressed, move right
     if (Input.GetKey(KeyCode.RightArrow)){
        Vector3 newPosition = transform.position;
        float pos = 0.20F;
        newPosition.x += pos;
        transform.position = newPosition;
     }


    }
   //  Get the speed of paddle
    public float getPaddleSpeed(){
      return paddleSpeed;
    }
}
