using UnityEngine;

public class BrickScriptBasic : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();

        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.useFullKinematicContacts = true;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        ContactPoint2D hit = collision.GetContact(0);
        rb.linearVelocity = Vector2.Reflect(rb.linearVelocity, hit.normal);

    }

    private void FixedUpdate(){
        Debug.Log(rb.linearVelocity.magnitude.ToString());
    }
   
}

