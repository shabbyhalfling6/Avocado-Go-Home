using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public float timeOut = 40.0f;
    private float timeOutIn = 0.0f;

    public string startGameButton = "enter";
    public string restartGameButton = "enter";
    public string exitGameButton = "escape";

    public GameObject mainMenu;
    public GameObject gameOverMenu;

    public Move player1;
    public Move player2;

    public bool endReached;

    public GameState currentGameState = GameState.MainMenu;

    public enum GameState
    {
        MainMenu,
        PlayGame,
        GameOver
    }

    public static GameController instance;

	// Use this for initialization
	void Start ()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        timeOutIn = timeOut;
        TogglePlayerMovement(false);

        mainMenu.SetActive(true);

        Time.timeScale = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        switch (currentGameState)
        {
            case GameState.MainMenu:
                {
                    if(Input.GetButtonDown(startGameButton))
                    {
                        currentGameState = GameState.PlayGame;
                        FadeTransition();

                        mainMenu.SetActive(false);

                        TogglePlayerMovement(true);

                        Time.timeScale = 1.0f;
                    }
                    break;
                }
            case GameState.PlayGame:
                {
                    UpdateTimeOut();

                    if (endReached)
                    {
                        currentGameState = GameState.GameOver;

                        TogglePlayerMovement(false);
                    }
                    break;
                }
            case GameState.GameOver:
                {
                    gameOverMenu.SetActive(true);

                    if (Input.GetButtonDown(restartGameButton))
                    {
                        ReloadGame();
                    }
                    break;
                }
            default:
                break;
        }

        if(Input.GetButtonDown(exitGameButton))
        {
            Application.Quit();
        }
	}

    void TogglePlayerMovement(bool playerMovement)
    {
        if (player1 != null && player2 != null)
        {
            player1.enabled = playerMovement;
            player2.enabled = playerMovement;
        }
    }

    void UpdateTimeOut()
    {
        if (Input.anyKey)
            timeOut = timeOutIn;
        else
            timeOut -= Time.deltaTime;



        if (timeOut <= 0.0f)
        {
            ReloadGame();
        }
    }

    void ReloadGame()
    {
        SceneManager.LoadScene(0);
    }

    void FadeTransition()
    {

    }
}
