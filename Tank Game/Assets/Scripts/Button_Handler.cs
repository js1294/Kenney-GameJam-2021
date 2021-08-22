using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button_Handler : MonoBehaviour
{
    public Button start, exit;
    public AudioSource startSound, exitSound;
    // Start is called before the first frame update
    void Start()
    {
        start.onClick.AddListener(StartGame);
        exit.onClick.AddListener(Exit);
    }

    void StartGame()
    {
        startSound.Play();
        SceneManager.LoadScene (sceneName:"Instructions");
    }

    void Exit()
    {
        Application.Quit();
        exitSound.Play();
    }
}
