using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIFinalScene : MonoBehaviour
{
    public Text points;
    public Text highScoreTxt;
    public int highScore;
    public Button menu;
    public Button quit;

    private string key = "123qwe";
    private GameObject gameManager;
    private GameManager manager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        manager = gameManager.GetComponent<GameManager>();
        if (PlayerPrefs.HasKey(key))
        {
            highScore = PlayerPrefs.GetInt(key);
        }

        menu.onClick.AddListener(GoToMenu);
        quit.onClick.AddListener(Quit);
    }

    private void Update()
    {
        points.text = "Points: " + manager.points;
        highScoreTxt.text = "Highscore: " + highScore;

    }

    public void GoToMenu()
    {
        Destroy(gameManager);
        SceneManager.LoadScene("IntroScene");
    }

    public void Quit()
    {
        #if UNITY_EDITOR
             UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }


}