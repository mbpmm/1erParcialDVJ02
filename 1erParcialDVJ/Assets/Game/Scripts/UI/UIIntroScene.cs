using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIIntroScene : MonoBehaviour
{
    public Button play;
    public Button quit;
    // Start is called before the first frame update
    void Start()
    {
        play.onClick.AddListener(GoToGameScene);
        quit.onClick.AddListener(Quit);
    }

    void GoToGameScene()
    {
        LoaderManager.Get().LoadScene("GameScene");
        UILoadingScreen.Get().SetVisible(true);
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
