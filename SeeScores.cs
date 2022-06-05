using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Text;
using UnityEngine.UI;



public class SeeScores : MonoBehaviour
{
    [SerializeField]
    public Text tbScores;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowScores());
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

            Debug.LogFormat("rec = {0}", rec[0]);
            Debug.LogFormat("rec = {0}", rec[1]);
            Debug.LogFormat("rec = {0}", rec[2]);
            Debug.LogFormat("rec = {0}", rec[3]);
            Debug.LogFormat("rec = {0}", rec[8]);
            Debug.Log(www.downloadHandler.text);

            byte[] results = www.downloadHandler.data;

            int counter = 0;
            var sb = new StringBuilder();
          for(int i =0;i<rec.Length;i++ )
            {
                if(counter<3)
                {
                    sb.Append(rec[i]).Append(" ");
                    counter++;
                }
                else
                {
                    sb.Append("\n");
                    sb.Append(rec[i]).Append(" ");
                    counter = 1;
                }
                
            }
            tbScores.text = sb.ToString();




        }
    }
}
