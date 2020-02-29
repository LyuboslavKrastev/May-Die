using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] private Canvas _gameOverCanvas;
    void Start()
    {
        _gameOverCanvas.enabled = false;
    }

    public void HandleDeath()
    {
        _gameOverCanvas.enabled = true;
        Time.timeScale = 0; // stop the game
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
