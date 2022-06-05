using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Sprite bluekralj;
    public int healthMax = 8;
    public int Attack = 2;
    public int healthCurrent;
    public int Attacktome;

    // Start is called before the first frame update
    void Start()
    {
        healthCurrent = healthMax;
    }

    void TakeDamage(int Attacktome)
    {
        healthCurrent -= Attacktome;

        if (healthCurrent <= 0)
        {
            DestroyMovePlates();
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
