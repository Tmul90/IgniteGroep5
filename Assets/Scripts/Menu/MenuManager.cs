using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string nextSceneName = "GameScene";

    public void PlayGame() => SceneManager.LoadScene(nextSceneName);
    

    public void QuitGame() => Application.Quit();
}
