using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MovePlate : MonoBehaviour
{
    public GameObject controller;
    GameObject reference = null;

    int matrixX;
    int matrixY;

    public bool attack = false;

   

    

    public void Start()
    {
        if(attack)
        {
            //Bojimo u crveno
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
    }

    public void OnMouseUp()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
       

        if (attack)
        {
            //cp = chesspiece
            GameObject cp = controller.GetComponent<Game>().GetPosition(matrixX, matrixY);
            Destroy(cp);
            //Ako je kralj pojeden onda je kraj 
            if (cp.name == "bluekralj")
            {
                controller.GetComponent<Game>().Winner("RED");
                StartCoroutine(Main.Instance.DataBase.UpdateWins(DBManager.username));

            }
            if (cp.name == "redkralj")
            {
                controller.GetComponent<Game>().Winner("BLUE");
                StartCoroutine(Main.Instance.DataBase.UpdateLosses(DBManager.username));


            }
        }
        if (controller.GetComponent<Game>().turnPlayed == false)
        {
            controller.GetComponent<Game>().SetPositionEmpty(reference.GetComponent<Chessman>().getXBoard(), reference.GetComponent<Chessman>().getYBoard());

            reference.GetComponent<Chessman>().SetXBoard(matrixX);
            reference.GetComponent<Chessman>().SetYBoard(matrixY);
            reference.GetComponent<Chessman>().SetCoords();

            controller.GetComponent<Game>().SetPosition(reference);



            controller.GetComponent<Game>().IsTurnPlayed();
            controller.GetComponent<Game>().turnPlayed = true;

            reference.GetComponent<Chessman>().DestroyMovePlates();
        }
       
    }


    public void SetCoords(int x ,int y)
        {
            matrixX = x;
            matrixY = y;
        }

        public void SetReference(GameObject obj)
        {
            reference = obj;
        }

        public GameObject GetReference()
        {
            return reference;
        }


}
