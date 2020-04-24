using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{

    public bool gameIsPause = false;
    public GameObject PauseText;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {

            if (gameIsPause)
            {

                Resume();

            }
            else
            {

                Pause();

            }
        }

        /*if (gameIsPause == true && Input.GetKeyDown(KeyCode.R))
        {

            ReloadGame();

        }

        if (gameIsPause == true && Input.GetKeyDown(KeyCode.H))
        {

            ExitGame();

        }*/


    }
    public void Resume()
    {
        Cursor.visible = false;
        PauseText.SetActive(false);
        Time.timeScale = 1f;
        gameIsPause = false;

    }
    void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PauseText.SetActive(true);
        Time.timeScale = 0f;
        gameIsPause = true;


    }
    public void ReloadGame()
    {

        Time.timeScale = 1f;
        SceneManager.LoadScene(0);

    }

    public void ExitGame()
    {

        Application.Quit();

    }
}
