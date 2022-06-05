using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public GameObject chesspiece;

    private GameObject[,] positions = new GameObject[7, 7];
    private GameObject[] playerRed = new GameObject[7];
    private GameObject[] playerBlue = new GameObject[7];

    private string currentPlayer = "blue";
    private bool gameOver = false;

    public bool turnPlayed = false;

    public Text playerDisplay;
    
    public bool IsTurnPlayed()
    {
        return turnPlayed;
    }

    
    // Start is called before the first frame update
    void Start()
    {
        if(DBManager.LoggedIn)
        {
            playerDisplay.text = "Player : " + DBManager.username;
        }
        playerBlue = new GameObject[]
        {
            Create("bluepion1",0,0), Create("bluepion2",1,0),Create("bluepion3",5,0),Create("bluepion4",6,0),Create("bluelovac1",4,0),Create("bluelovac2",2,0),Create("bluekralj",3,0)
        };

        playerRed = new GameObject[]
       {
            Create("redpion1",0,6), Create("redpion2",1,6),Create("redpion3",5,6),Create("redpion4",6,6),Create("redlovac1",4,6),Create("redlovac2",2,6),Create("redkralj",3,6)
       };
        //Namesta pozicije figura
        for(int i=0; i<playerBlue.Length; i++)
        {
            SetPosition(playerBlue[i]);
            SetPosition(playerRed[i]);
        }

    }

    public GameObject Create(string name,int x, int y)
    {
        GameObject obj = Instantiate(chesspiece, new Vector3(0, 0, -1), Quaternion.identity);
        Chessman cm = obj.GetComponent<Chessman>();
        cm.name = name;
        cm.SetXBoard(x);
        cm.SetYBoard(y);
        cm.Activate();
        return obj;
    }

    public void SetPosition(GameObject obj)
    {
        Chessman cm = obj.GetComponent<Chessman>();
        positions[cm.getXBoard(), cm.getYBoard()] = obj;
    }

    public void SetPositionEmpty(int x, int y )
    {
        positions[x, y] = null;
    }
    public GameObject GetPosition(int x, int y)
    {
        return positions[x, y];
    }
    public bool PositionOnBoard(int x ,int y)
    {
        if (x < 0 || y < 0 || x >= positions.GetLength(0) || y >= positions.GetLength(1))
        {
            return false;
        }
        else
        {
            return true;
        }


    }

    //Definisemo playere
    public string GetCurrentPlayer()
    {
        return currentPlayer;
    }

    public bool IsGameOver()
    {
        return gameOver;
    }
    //Menjamo playera koji igra TREBA DA SE UBACI DUGME ZA KRAJ POTEZA KOJE CE OVO POZVATI 
    public void NextTurn()
    {
        if (turnPlayed == true)
        {


            if (currentPlayer == "red")
            {
                currentPlayer = "blue";
            }
            else
            {
                currentPlayer = "red";
            }
            turnPlayed = false;
        }
    }
    public void Winner(string playerWinner)
    {
        gameOver = true;

        GameObject.FindGameObjectWithTag("WinnerText").GetComponent<Text>().enabled = true;
        GameObject.FindGameObjectWithTag("WinnerText").GetComponent<Text>().text = playerWinner + " IS THE WINNER \n CLICK TO RESTART ";

    }

    //Ako je zavrseno i igrac klikne....
    public void Update()
    {
        if(gameOver == true && Input.GetMouseButtonDown(0) )
        {
            //Restartujemo igru
            gameOver = false;
            SceneManager.LoadScene("Game"); 
        }
    }
    

}
