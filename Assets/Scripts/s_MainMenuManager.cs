using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class s_MainMenuManager : MonoBehaviour
{
    //Variables
    private int sizeX;
    private int sizeZ;


    public GameObject MainMenuCanvas;
    public GameObject NewGameCanvas;

    public void BtnNewGame()
    {
        MainMenuCanvas.SetActive(false);
        NewGameCanvas.SetActive(true);
    }

    public void BtnLoadGame()
    {
        //TODO 
    }

    public void BtnQuitGame()
    {
        Application.Quit();
    }

    public void BtnCreatePresetLevel()
    {
        SceneManager.LoadScene("Level_PresetWorld");
    }

    public void BtnCreateEmptyLevel()
    {
        //TODO
    }

    public void BtnBack(int button)
    {
        switch(button)
        {
            case 1:
            {
                NewGameCanvas.SetActive(false);
                MainMenuCanvas.SetActive(true);
                break;
            }
            default:
                break;        
        }
    }

    public void BtnLaunchGame()
    {
        //ToDo
    }

    void Start()
    {
        MainMenuCanvas.SetActive(true);
        NewGameCanvas.SetActive(false);
    }
}
