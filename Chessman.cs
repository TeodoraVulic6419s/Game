using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chessman : MonoBehaviour
{
    //References
    public GameObject controller;
    public GameObject movePlate;

    //Position
    private int xBoard = -1;
    private int yBoard = -1;

    //Variable to keep track of "blue" player or "red" player
    private string player;

    //References for all the sprites that the chesspiece can be
    public Sprite redkralj, redlovac, redpion;
    public Sprite bluekralj, bluelovac, bluepion;

    public void Activate()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        //take the instantiated location and adjust the transform
        SetCoords();

        switch (this.name)
        {
            case "redkralj": this.GetComponent<SpriteRenderer>().sprite = redkralj; break;
            case "redlovac": this.GetComponent<SpriteRenderer>().sprite = redlovac; break;
            case "redpion": this.GetComponent<SpriteRenderer>().sprite = redpion; break;

            case "bluekralj": this.GetComponent<SpriteRenderer>().sprite = bluekralj; break;
            case "bluelovac": this.GetComponent<SpriteRenderer>().sprite = bluelovac; break;
            case "bluepion": this.GetComponent<SpriteRenderer>().sprite = bluepion; break;

        }
    }

    public void SetCoords()
    {
        float x = xBoard;
        float y = yBoard;

        x *= 0.8f;
        y *= 0.66f;

        x += -3.2f;
        y += -2.3f;

        this.transform.position = new Vector3(x, y, -1.0f);
    }

    public  int GetXBoard()
    {
        return xBoard;  
    }

    public int GetYBoard()
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
}
