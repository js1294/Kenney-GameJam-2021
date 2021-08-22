using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Button_Handler_Instructions : MonoBehaviour
{
    public Button start, exit;
    public AudioSource exitSound;
    // Start is called before the first frame update
    void Start()
    {
        start.onClick.AddListener(StartGame);
        exit.onClick.AddListener(Exit);
    }

    void StartGame()
    {
        SceneManager.LoadScene (sceneName:"MainGame");
    }

    void Exit()
    {
        exitSound.Play();
        SceneManager.LoadScene (sceneName:"MainMenu");
    }
}
