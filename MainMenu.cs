using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button btnGame;
    public Button btnScores;
    public Button btnExit;

    // Start is called before the first frame update
    void Start()
    {
        btnGame.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Game");
        });

        btnScores.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Scores");
        });

        btnExit.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("StartScreen");

        });
    }

    
}
