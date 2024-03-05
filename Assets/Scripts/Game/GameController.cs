using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameStartScreen;
    
    [SerializeField]
    private GameObject _gameScreen;
    
    [SerializeField]
    private GameObject _gameOverScreen;

    [SerializeField]
    private float _gameOverScreenShowDelay; //задержка до появления экрана окончания игры
    
    [SerializeField]
    private SquareSpawner _squareSpawner;
    
    private bool _wasGameOver;
    
    private void Awake()
    {
        _gameScreen.SetActive(false);
        _gameOverScreen.SetActive(false);
        _gameStartScreen.SetActive(true);
    }
    
    private void Update()
    {
        if (_wasGameOver)
        {
            _gameOverScreenShowDelay -= Time.deltaTime;

            if (_gameOverScreenShowDelay <= 0)
            {
                ShowGameOverScreen();
            }
        }
    }
    
    public void StartGame()
    {
        _gameStartScreen.SetActive(false);
        _gameScreen.SetActive(true);
    }
    
    public void RestartGame()
    {
        var sceneName = SceneManager.GetActiveScene().name; //получаем название сцены
        SceneManager.LoadSceneAsync(sceneName); //загружаем данную сцену
    }
    
    public void OnPlayerDied()
    {
        _wasGameOver = true;
        _squareSpawner.enabled = false;
    }
    
    private void ShowGameOverScreen()
    {
        _gameScreen.SetActive(false);
        _gameOverScreen.SetActive(true);
    }
}
