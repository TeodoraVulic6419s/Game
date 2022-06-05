using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Register : MonoBehaviour
{
    [SerializeField]
    public InputField InUser;
    public InputField InPass;
    public InputField InConfirm;
    public Button btnRegister;
    public Button btnBack;

    void Start()
    {
        btnRegister.onClick.AddListener(() =>
        {
            StartCoroutine(Main.Instance.DataBase.Register(InUser.text, InPass.text, InConfirm.text));
        });

        btnBack.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("StartScreen");
        });


    }

}
