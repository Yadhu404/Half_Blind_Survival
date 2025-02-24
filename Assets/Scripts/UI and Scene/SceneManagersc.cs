using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagersc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hometoloadscene(){
        SceneManager.LoadScene("GameScene1"); //Loading from Load Scene to Game Scene
        Time.timeScale = 1f;
        // StartCoroutine(LoadtogameScene());
    }

    private IEnumerator LoadtogameScene(){
        SceneManager.LoadScene("LoadScene"); //Loading from Home Scene to Load Scene

        yield return new WaitForSeconds(0f);

        SceneManager.LoadScene("GameScene1"); //Loading from Load Scene to Game Scene
    }

    public void GametoHomescene(){
        SceneManager.LoadScene("StartScene");  //Loading from game to Home scene
    }

    public void RestartGame(){    //To restart the game.
        Scene CurrentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(CurrentScene.name);

        Time.timeScale = 1f;
    }
}
