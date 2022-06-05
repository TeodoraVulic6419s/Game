using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Text;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class SeeScores : MonoBehaviour
{
    [SerializeField]
    public Text tbScores;
    public Button btnExit;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowScores());

        btnExit.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("MainMenu");

        });
    }
    public IEnumerator ShowScores()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/RVAS_Projekat1/ShowScores.php"))
        {
            yield return www.SendWebRequest();
            var niz = www.downloadHandler.text;
            var rec1 = niz.Replace("[", "");
            rec1 = rec1.Replace("]", "");
            rec1 = rec1.Replace("\",\""," ");
            rec1 = rec1.Replace("\"", "");
            var rec = rec1.Split(" ");

          

            byte[] results = www.downloadHandler.data;

            int counter = 0;
            var sb = new StringBuilder();
            int rez = 1;
           


                for (int i = 0; i < rec.Length; i++)
                {
                    if (counter < 3)
                    {
                        sb.Append(rec[i]).Append("   ");
                        counter++;
                        
                    }
                    else
                    {
                        sb.Append("\n");
                        sb.Append(rec[i]).Append("   ");
                        counter = 1;
                        
                    }

                }
                
            
            tbScores.text = sb.ToString();




        }
    }
}
