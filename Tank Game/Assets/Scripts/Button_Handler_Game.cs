using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button_Handler_Game : MonoBehaviour
{
    public Button exit;
    public AudioSource exitSound;
    // Start is called before the first frame update
    void Start()
    {
        exit.onClick.AddListener(Exit);
    }

        void Exit()
    {
        exitSound.Play();
        SceneManager.LoadScene (sceneName:"MainMenu");
    }
}
