using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string nextSceneName = "GameScene"; // you can change the scene name to change what scene you go to

    public void PlayGame() => SceneManager.LoadScene(nextSceneName); // loads scene with the decided scene name
    

    public void QuitGame() => Application.Quit(); // quits application
}
