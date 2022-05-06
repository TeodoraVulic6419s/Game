using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    public GameObject chesspiece;

    //Positions and team for each chesspiece
    private GameObject[,] positions = new GameObject[7, 7];
    private GameObject[] playerRed = new GameObject[14];
    private GameObject[] playerBlue = new GameObject[14];

    private string currentPlayer = "red";

    private bool gameOver = false;



    // Start is called before the first frame update
    void Start()
    {
        ///Instantiate(chesspiece, new Vector3(0, 0, -1), Quaternion.identity);

        playerRed = new GameObject[]
        { Create("redkralj",4,0), 
            Create("redlovac",5,0),
            Create("redlovac",3,0),
            Create("redpion",1,0),
            Create("redpion",2,0),
            Create("redpion",6,0),
            Create("redpion",7,0),

        };
        playerBlue = new GameObject[]
        { Create("bluekralj",4,7),
            Create("bluelovac",5,7),
            Create("bluelovac",3,7),
            Create("bluepion",1,7),
            Create("bluepion",2,7),
            Create("bluepion",6,7),
            Create("bluepion",7,7),

        };

        //Set all piece position on the position board
        for (int i = 0; i < playerRed.Length; i++)
        {
            SetPosition(playerRed[i]);
            SetPosition(playerBlue[i]);
        }
    }

    public GameObject Create(string name, int x, int y)
    {
        GameObject obj = Instantiate(chesspiece, new Vector3(0,0,-1), Quaternion.identity);  
        Chessman cm = obj.GetComponent<Chessman>(); 
        cm.name = name; 
        cm.SetXBoard(x);
        cm.SetYBoard(y);
        cm.Activate();
        return obj;
   
    }

    public void SetPosition(GameObject obj)
    {
        Chessman cm = GetComponent<Chessman>();

        positions[cm.GetXBoard(), cm.GetYBoard()] = obj;
    }
}
