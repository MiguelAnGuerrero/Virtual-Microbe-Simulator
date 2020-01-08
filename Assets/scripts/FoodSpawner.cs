using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject Nitrate;
    public GameObject Phosphate;
    public GameObject Silicate;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= 100; i++) {
            Instantiate(Nitrate);
        }
        for (int i = 0; i <= 100; i++)
        {
            Instantiate(Phosphate);
        }
        for (int i = 0; i <= 100; i++)
        {
            Instantiate(Silicate);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
