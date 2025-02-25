using Unity.VisualScripting;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public float moveSpeed = 5f;
    Vector3 targetPosition = new Vector3 (0f,4.15f,0f);

    public GameObject[] fallingBricks;
    public float holeDist = 5f;
    float BrickdropDist;
    
    private Rigidbody bh;

    public GameOverScript GameOverScript;

    void Start()
    {
        bh = GetComponent<Rigidbody>();

        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        foreach(GameObject fallingBrick in fallingBricks){
            if (fallingBrick != null){
                float BrickdropDist = Vector3.Distance(transform.position, fallingBrick.transform.position);
                if (BrickdropDist <= holeDist){
                    StartFalling(fallingBrick);
                    GameOverScript.Setup();

                    
                }
                // Debug.Log(BrickdropDist);
            }
        }
        

    }

    void StartFalling(GameObject fallingBrick){
        Rigidbody rb = fallingBrick.GetComponent<Rigidbody>(); 
        if (rb == null){
            rb = fallingBrick.AddComponent<Rigidbody>();
        }
        rb.isKinematic = false;
        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;

    }
        
    }
