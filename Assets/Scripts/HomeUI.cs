using UnityEngine;

public class HomeUI : MonoBehaviour
{
      public void StartButton()
    {
               UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    public void QuitButton()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
