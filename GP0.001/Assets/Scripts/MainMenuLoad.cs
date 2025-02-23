using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLoad : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");

    }
}
