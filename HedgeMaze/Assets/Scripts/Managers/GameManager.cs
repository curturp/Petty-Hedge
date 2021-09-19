using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Pathfinding;


public class GameManager : MonoBehaviour
{
    // Made using the help of Brackeys Tutorials - https://www.youtube.com/user/Brackeys

    public static bool GameStart;
    public static bool GameIsOver;
    public static bool GameIsPause;
    private bool GameInfoDisplay;
    //private bool StartGameDisplay;

    public static GameObject pathfinderObj;
    GameObject goalObj;

    AILerp pathfinderAi;
        
    public GameObject gameOverUi;

    public GameObject gameInfoUi;

    public GameObject pauseGameUI;

    public GameObject startGameUi;

    public GameObject altGameOverUi;

    public static float TimeScore;

    private void Awake()
    {
        Time.timeScale = 0f;
    }

    private void Start()
    {
        GameStart = false;
        GameIsOver = false;
        GameIsPause = false;
        GameInfoDisplay = false;
        //StartGameDisplay = true;
        TimeScore = 0f;

        pathfinderAi = pathfinderObj.GetComponent<AILerp>();
    }

    private void Update()
    {

        if (!GameStart)
        {
            Time.timeScale = 0f;
            return;
        }

        if (GameIsOver)
            return;

        if (!pathfinderAi.reachedDestination && pathfinderAi.reachedEndOfPath)
        {
            AltEndGame();
        }

        if (pathfinderAi.reachedDestination)
        {
            EndGame();
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            GameInfoDispaly();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetGame();
        }

        if (pauseGameUI.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else Time.timeScale = 1f;

    }

    public void StartGame()
    {
        if (!GameStart)
        {
            GameStart = true;
            Time.timeScale = 1f;

            //StartGameDisplay = false;
            startGameUi.SetActive(false);

            if (gameInfoUi.activeSelf)
            {
                GameInfoDisplay = !GameInfoDisplay;
                gameInfoUi.SetActive(!gameInfoUi.activeSelf);
            }
        }        
    }

    void EndGame()
    {
        GameIsOver = true;
        gameOverUi.SetActive(true);
    }

    void AltEndGame()
    {
        GameIsOver = true;
        altGameOverUi.SetActive(true);
    }

    public void PauseGame()
    {
        if (GameStart)
        {
            GameIsPause = !GameIsPause;
            pauseGameUI.SetActive(!pauseGameUI.activeSelf);

            if (GameInfoDisplay)
            {
                GameInfoDisplay = !GameInfoDisplay;
                gameInfoUi.SetActive(!gameInfoUi.activeSelf);
            }
        }
        
    }

    public void GameInfoDispaly()
    {
        
        GameInfoDisplay = !GameInfoDisplay;
        gameInfoUi.SetActive(!gameInfoUi.activeSelf);

        if (!GameIsPause && GameStart)
        {
            GameIsPause = !GameIsPause;
            pauseGameUI.SetActive(!pauseGameUI.activeSelf);
        }
        
        
    }

    public void SetGoal(GameObject goal)
    {
        goalObj = goal;
    }

    public void SetPathFinder(GameObject pathFinder)
    {
        pathfinderObj = pathFinder;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
