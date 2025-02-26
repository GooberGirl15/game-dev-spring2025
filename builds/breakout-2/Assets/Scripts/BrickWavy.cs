using Unity.VisualScripting;
using UnityEngine;

public class BrickScriptWavy : MonoBehaviour


{
    private Rigidbody2D rb;
    Vector2 randomOffset;
    public float rando1 = -0.2F;
    public float rando2 = 0.2F;

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();

        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.useFullKinematicContacts = true;

        randomOffset = new Vector2 (Random.Range(rando1, rando2),Random.Range(rando1,rando2));

    }

    private void OnCollisionEnter2D(Collision2D collision){
        ContactPoint2D hit = collision.GetContact(0);
        rb.linearVelocity = Vector2.Reflect(rb.linearVelocity, hit.normal);

    }

    private void FixedUpdate(){
        // Debug.Log(rb.linearVelocity.magnitude.ToString());
    }
   
}
