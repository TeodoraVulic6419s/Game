uusing System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chessman : MonoBehaviour
{
    // Reference
    public GameObject controller;
    public GameObject movePlate;

    //Health i Attack
    public int hlt;
    public int atk;

    //Pozicije
    private int xBoard = -1;
    private int yBoard = -1;

    //Varijabla za igraca (plavi ili crveni)
    private string player;

    //Refernce na sprajtove koja figura moze da bude
    public Sprite bluekralj, bluelovac, bluepion;
    public Sprite redkralj, redlovac, redpion;
    //Svaki vojnik ima 2 attack i 3 health, strelac 3 attack i 4 health, dok kralj ima 2 attack i 8 health.
    private void Start()
    {
        switch (this.name)
        {
            case "redkralj":
            case "bluekralj":
                atk = 2;
                hlt = 8;
                break;
            case "redlovac1":
            case "redlovac2":
            case "bluelovac1":
            case "bluelovac2":
                atk = 3;
                hlt = 4;
                break;
            case "redpion1":
            case "redpion2":
            case "redpion3":
            case "redpion4":
            case "bluepion1":
            case "bluepion2":
            case "bluepion3":
            case "bluepion4":
                atk = 2;
                hlt = 3;
                break;
        }

    }
    public void Activate()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        //Uzima instanciranu lokaciju i namesta transformaciju
        SetCoords();

        switch (this.name)
        {
            case "redkralj":
                this.GetComponent<SpriteRenderer>().sprite = redkralj; player = "red";
                break;
            case "redlovac1":
                this.GetComponent<SpriteRenderer>().sprite = redlovac;
                player = "red"; break;
            case "redlovac2":
                this.GetComponent<SpriteRenderer>().sprite = redlovac;
                player = "red"; break;
            case "redpion1":
                this.GetComponent<SpriteRenderer>().sprite = redpion;
                player = "red"; break;
            case "redpion2":
                this.GetComponent<SpriteRenderer>().sprite = redpion;
                player = "red"; break;
            case "redpion3":
                this.GetComponent<SpriteRenderer>().sprite = redpion;
                player = "red"; break;
            case "redpion4":
                this.GetComponent<SpriteRenderer>().sprite = redpion;
                player = "red"; break;
            case "bluekralj":
                this.GetComponent<SpriteRenderer>().sprite = bluekralj;
                player = "blue"; break;
            case "bluelovac1":
                this.GetComponent<SpriteRenderer>().sprite = bluelovac;
                player = "blue"; break;
            case "bluelovac2":
                this.GetComponent<SpriteRenderer>().sprite = bluelovac;
                player = "blue"; break;
            case "bluepion1":
                this.GetComponent<SpriteRenderer>().sprite = bluepion;
                player = "blue"; break;
            case "bluepion2":
                this.GetComponent<SpriteRenderer>().sprite = bluepion;
                player = "blue"; break;
            case "bluepion3":
                this.GetComponent<SpriteRenderer>().sprite = bluepion;
                player = "blue"; break;
            case "bluepion4":
                this.GetComponent<SpriteRenderer>().sprite = bluepion;
                player = "blue"; break;
        }
    }
    public void SetCoords()
    {
        float x = xBoard;
        float y = yBoard;

        x *= 1.11f;
        y *= 1.1f;

        x += -3.32f;
        y += -3.27f;

        this.transform.position = new Vector3(x, y, -1.0f);
    }

    public int getXBoard()
    {
        return xBoard;
    }

    public int getYBoard()
    {
        return yBoard;
    }

    public void SetXBoard(int x)
    {
        xBoard = x;
    }
    public void SetYBoard(int y)
    {
        yBoard = y;
    }

    private void OnMouseUp()
    {
        if (!controller.GetComponent<Game>().IsGameOver() && controller.GetComponent<Game>().GetCurrentPlayer() == player)
        {
            DestroyMovePlates();

            InitiateMovePlates();
        }

    }

    public void DestroyMovePlates()
    {
        GameObject[] movePlates = GameObject.FindGameObjectsWithTag("MovePlate");
        for (int i = 0; i < movePlates.Length; i++)
        {
            Destroy(movePlates[i]);
        }
    }
    //Namestamo pomeranja za svaku figuru
    public void InitiateMovePlates()
    {
        switch (this.name)
        {
            case "redkralj":
            case "bluekralj":
                KingMovePlate();
                break;
            case "redlovac1":
            case "redlovac2":
            case "bluelovac1":
            case "bluelovac2":
                ArcherMovePlate();
                break;
            case "redpion1":
            case "redpion2":
            case "redpion3":
            case "redpion4":
                WarriorRedMovePlate(xBoard, yBoard);
                break;
            case "bluepion1":
            case "bluepion2":
            case "bluepion3":
            case "bluepion4":
                WarriorBlueMovePlate(xBoard, yBoard);
                break;
        }
    }

    public void ArcherMovePlate()
    {
        PointMovePlate(xBoard + 1, yBoard + 2);
        PointMovePlate(xBoard - 1, yBoard + 2);
        PointMovePlate(xBoard + 2, yBoard + 1);
        PointMovePlate(xBoard + 2, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard - 2);
        PointMovePlate(xBoard - 1, yBoard - 2);
        PointMovePlate(xBoard - 2, yBoard + 1);
        PointMovePlate(xBoard - 2, yBoard - 1);

    }

    public void KingMovePlate()
    {
        PointMovePlate(xBoard, yBoard + 1);
        PointMovePlate(xBoard, yBoard - 1);
        PointMovePlate(xBoard - 1, yBoard + 1);
        PointMovePlate(xBoard - 1, yBoard - 1);
        PointMovePlate(xBoard - 1, yBoard - 0);
        PointMovePlate(xBoard + 1, yBoard + 1);
        PointMovePlate(xBoard + 1, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard - 0);

    }

    public void PointMovePlate(int x, int y)
    {
        Game sc = controller.GetComponent<Game>();
        if (sc.turnPlayed == false)
        {
            if (sc.PositionOnBoard(x, y))
            {

                GameObject cp = sc.GetPosition(x, y);
                //Proveravamo da li ima figura na polju, i ako ima cija je figura
                if (cp == null)
                {
                    MovePlateSpawn(x, y);

                }
                else if (cp.GetComponent<Chessman>().player != player)
                {
                    MovePlateAttackSpawn(x, y);
                }
            }
        }
    }

    public void WarriorRedMovePlate(int x, int y)
    {
        PointMovePlate(xBoard + 1, yBoard - 1);
        PointMovePlate(xBoard - 1, yBoard - 1);
        PointMovePlate(xBoard, yBoard - 1);
    }

    public void WarriorBlueMovePlate(int x, int y)
    {
        PointMovePlate(xBoard + 1, yBoard + 1);
        PointMovePlate(xBoard - 1, yBoard + 1);
        PointMovePlate(xBoard, yBoard + 1);
    }
    // Namestamo da nam se pojavi MovePlate
    public void MovePlateSpawn(int matrixX, int matrixY)
    {
        if (controller.GetComponent<Game>().turnPlayed == false)
        {
            float x = matrixX;
            float y = matrixY;

            x *= 1.11f;
            y *= 1.1f;

            x += -3.32f;
            y += -3.27f;


            GameObject mp = Instantiate(movePlate, new Vector3(x, y, -3.0f), Quaternion.identity);

            MovePlate mpScript = mp.GetComponent<MovePlate>();
            mpScript.SetReference(gameObject);
            mpScript.SetCoords(matrixX, matrixY);
        }
    }

    public void MovePlateAttackSpawn(int matrixX, int matrixY)
    {
        float x = matrixX;
        float y = matrixY;

        x *= 1.11f;
        y *= 1.1f;

        x += -3.32f;
        y += -3.27f;

        GameObject mp = Instantiate(movePlate, new Vector3(x, y, -3.0f), Quaternion.identity);

        MovePlate mpScript = mp.GetComponent<MovePlate>();
        mpScript.attack = true;
        mpScript.SetReference(gameObject);
        mpScript.SetCoords(matrixX, matrixY);
    }

    public void Atrributes()
    {
        switch (this.name)
        {
            case "redkralj":
            case "bluekralj":
                atk = 2;
                hlt = 8;
                break;
            case "redlovac1":
            case "redlovac2":
            case "bluelovac1":
            case "bluelovac2":
                ArcherMovePlate();
                atk = 3;
                hlt = 4;
                break;
            case "redpion1":
            case "redpion2":
            case "redpion3":
            case "redpion4":
                WarriorRedMovePlate(xBoard, yBoard);
                atk = 2;
                hlt = 3;
                break;
            case "bluepion1":
            case "bluepion2":
            case "bluepion3":
            case "bluepion4":
                WarriorBlueMovePlate(xBoard, yBoard);
                atk = 2;
                hlt = 3;
                break;

        }


    }
}