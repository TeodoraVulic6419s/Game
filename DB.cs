using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DB : MonoBehaviour
{
    private void Start()
    {
        //StartCoroutine(GetUsers());
        //StartCoroutine(Login("potasevic", "123"));
        //StartCoroutine(Register("ppetrovic", "1234"));
    }

    IEnumerator GetUsers()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/RVAS_Projekat1/GetUsers.php"))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //Vraca podatke kao tekst
                Debug.Log(www.downloadHandler.text);

                //Vraca podatke kako binarne podatke
                byte[] results = www.downloadHandler.data;
            }

        }
    }
    public IEnumerator Login(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/RVAS_Projekat1/Login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);

            }
        }
    }

    public IEnumerator Register(string username, string password, string confirm)
    {
        WWWForm form = new WWWForm();
        form.AddField("RegUser", username);
        form.AddField("RegPass", password);
        form.AddField("RegConfirm", confirm);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/RVAS_Projekat1/Register.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);

            }
        }
    }
    public IEnumerator UpdateWins(string username)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/RVAS_Projekat1/Wins.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                Debug.Log(www);

            }
        }
    }

        public IEnumerator UpdateLosses(string username)
        {
            WWWForm form = new WWWForm();
            form.AddField("username", username);

            using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/RVAS_Projekat1/Losses.php", form))
            {
                yield return www.SendWebRequest();

                if (www.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    Debug.Log(www.downloadHandler.text);
                    Debug.Log(www);

                }
            }


        }

}
