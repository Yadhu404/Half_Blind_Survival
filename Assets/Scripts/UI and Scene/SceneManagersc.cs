using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagersc : MonoBehaviour
{
    public static SceneManagersc instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayOnNewGame()
    {
        SceneManager.LoadScene("GameScene1"); //Loading from Load Scene to Game Scene
        Time.timeScale = 1f;
    }
    public void NewGame(){
        ResetSavedVariables.instance.ResetVariables();

        SceneManager.LoadScene("GameScene1"); //Loading from Load Scene to Game Scene
        Time.timeScale = 1f;
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene("GameScene1"); //Loading from Load Scene to Game Scene
        Time.timeScale = 1f;
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
