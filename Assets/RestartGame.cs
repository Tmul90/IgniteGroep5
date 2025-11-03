using System;
using System.Diagnostics;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    [SerializeField] private MenuManager menuManager;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            string exePath = Application.dataPath.Replace("_Data", ".exe");
            
            Process.Start(exePath);
            
            Application.Quit();
        }
    }
}
