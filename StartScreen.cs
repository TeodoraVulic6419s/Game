using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    [SerializeField]
    public Button btnLogin;
    public Button btnRegister;
    private void Start()
    {
        btnLogin.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Login");
        });

        btnRegister.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Register");
        });

        
    }
}
