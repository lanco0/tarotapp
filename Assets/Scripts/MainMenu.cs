using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Scene3()
    {
        SceneManager.LoadScene("Scene3");
    }
    public void Scene5()
    {
        SceneManager.LoadScene("Scene5");
    }
    public void Scene10()
    {
        SceneManager.LoadScene("Scene10");
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("SampleScene");
    }
}