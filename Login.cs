using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public InputField InUser;
    public InputField InPass;
    public Button btnLogin;
    
    public void CallLogin()
    {
        StartCoroutine(Loginn());

    }
    public IEnumerator Loginn()
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", InUser.text);
        form.AddField("loginPass", InPass.text);

        WWW www = new WWW("http://localhost/RVAS_Projekat1/Login.php", form);
        yield return www;

        //Proveravamo da nema gresaka

        if(www.text[0] == '0')
        {
            DBManager.username = InUser.text;

            
            SceneManager.LoadScene("MainMenu");

        }
        else
        {
            Debug.Log("User login failed" + www.text);
            Debug.Log(www.text[1]);
        }
       
    }
}
