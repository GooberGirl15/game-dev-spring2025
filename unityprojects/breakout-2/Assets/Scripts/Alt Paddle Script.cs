using System.Globalization;
using UnityEngine;

public class AltPaddleScript : MonoBehaviour
{
   Vector2 lastPosition;
   Vector2 currentPosition;
   public float positionDifference = 0;
    // private int paddleDirection = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      lastPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
      lastPosition = transform.position;

    // paddleSpeed declaration 
      

     // if left is pressed, move left
     if (Input.GetKey(KeyCode.LeftArrow)){
        Vector2 newPosition = transform.position;
        float pos = 0.15F;
        newPosition.x -= pos;
        transform.position = newPosition;
     }

     //if right is pressed, move right
     if (Input.GetKey(KeyCode.RightArrow)){
        Vector2 newPosition = transform.position;
        float pos = 0.15F;
        newPosition.x += pos;
        transform.position = newPosition;
     }

     currentPosition = transform.position;
    positionDifference = currentPosition.x - lastPosition.x;
    // Debug.Log("Last Position is:" + lastPosition.x);
    // Debug.Log("Current Position is : "+ currentPosition.x);
    // Debug.Log(positionDifference);

    GetPaddleDirection();

    }
   
   public int GetPaddleDirection(){
        if (positionDifference > 0){
          return 1;
        } if (positionDifference == 0) {
          return 0;
          
        } if (positionDifference < 0){
          return -1;
        }
        return 0;
   }
}
