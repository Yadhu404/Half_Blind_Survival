using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject HomePage;
    public GameObject PauseMenu;
    public GameObject ControlPage;
    public bool flag = true;
    // Start is called before the first frame update
    void Start()
    {
        // if(HomePage != null){
        //     HomePage.SetActive(false);
        // }

        if(PauseMenu != null){
            PauseMenu.SetActive(false);
        }

        if(ControlPage != null){
            ControlPage.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("p")){  //Alternate click on p to pause and resume the game
            if(flag){
                Pause();

                flag = false;
            }
            else{
                Resume();
                
                flag = true;
            }
        }
    }

    public void GotoHomePage(){
        HomePage.SetActive(true);
        ControlPage.SetActive(false);
    }

    public void Pause(){
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;       //Pause the whole game
    }
    public void Resume(){
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;      //Resume the whole game
    }


    public void ShowControls(){
        HomePage.SetActive(false);               //To show the controls
        ControlPage.SetActive(true);
    }
}
