using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
   
   public void Setup(){
    gameObject.SetActive(true);

   }

   public void RestartButton(){
      SceneManager.LoadScene("Level Two");

   }

   public void ExitButton(){
   //  SceneManager.LoadScene("MainMenu");
   }
}
