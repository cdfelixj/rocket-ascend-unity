using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseMenu;

    private bool cursorOn = true;
    void Start()
    {
        Cursor.visible = cursorOn;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseMenu.activeSelf)
            {
                Time.timeScale = 0f;
                pauseMenu.SetActive(true);
                Cursor.visible = cursorOn;
            }
            else
            {
                Time.timeScale = 1f;
                pauseMenu.SetActive(false);
                Cursor.visible = cursorOn;
            }
        }
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Resume()
    {

        Debug.Log("Resume");
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        Cursor.visible = cursorOn;
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
