using System;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    [SerializeField] private MenuManager menuManager;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace)) menuManager.PlayGame();
    }
}
