using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public void NextScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}