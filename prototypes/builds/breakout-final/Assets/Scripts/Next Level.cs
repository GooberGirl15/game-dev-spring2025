using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    public List<GameObject> bricks = new List<GameObject>();

    public GameObject prefabBrick;
    void Start()
    {
    }
    


    void Update()
    {
        Debug.Log("Bricks Left:" + bricks.Count);
       if (bricks.Count == 0){
        SceneManager.LoadScene("Level Two");
    }
    }
}
