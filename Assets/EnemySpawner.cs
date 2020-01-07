using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    void Start()
    {
        for (int i = 0; i <= 10; i++)
        {
            Instantiate(Enemy1);
        }
        //for (int i = 0; i <= 100; i++)
        //{
        //Instantiate(Phosphate);
        //}
        //for (int i = 0; i <= 100; i++)
        //{
        // Instantiate(Silicate);
        //}
    }

    // Update is called once per frame
    void Update()
    {

    }
}
