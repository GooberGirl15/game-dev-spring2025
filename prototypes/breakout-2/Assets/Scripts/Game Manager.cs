using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives = 3;
    public int level = 1;
 private void Awake(){
    DontDestroyOnLoad(this.gameObject);
 }

 private void Start(){
    NewGame();
 }

 private void NewGame(){
    this.lives = 3;
    LoadLevel(1);

 }

 private void LoadLevel(int level){
    this.level = level;

    SceneManager.LoadScene("Level" + level);
 }
}
