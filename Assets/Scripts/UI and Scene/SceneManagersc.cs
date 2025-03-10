using System;
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
        LoadToLoadScene(); //Loading from Load Scene to Game Scene
    }
    public void NewGame(){
        ResetSavedVariables.instance.ResetVariables();

        LoadToLoadScene(); //Loading from Load Scene to Game Scene
    }

    public void ContinueGame()
    {
        LoadToLoadScene(); //Loading from Load Scene to Game Scene
    }

    public void GametoHomescene(){
        SceneManager.LoadScene("StartScene");  //Loading from game to Home scene
        Time.timeScale = 1f;
    }

    public void RestartGame(){    //To restart the game.
        Scene CurrentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(CurrentScene.name);

        Time.timeScale = 1f;
    }


    public void LoadToLoadScene()
    {
        SceneManager.LoadScene("LoadScene");
    } 
}
