using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawnPoint;

    public GameObject newObject;

    public GameObject currentObject;

  
    void Start()
    {
        // SpawnObject();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentObject != null){
            DestroyObject();
        } 

        if (currentObject== null && Input.GetKeyDown(KeyCode.Space)){
            SpawnObject();
        }

        Debug.Log(transform.position.y);
    }

    void DestroyObject(){
        if (transform.position.y < -6f){
            Destroy(currentObject);
            currentObject = null;

        }
}

void SpawnObject(){
        currentObject = Instantiate(newObject,spawnPoint.position,spawnPoint.rotation);

    }
}
