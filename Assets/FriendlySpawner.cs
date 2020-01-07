using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlySpawner : MonoBehaviour
{
    public GameObject Ceratium;
    public GameObject Chaetoceros;
    public GameObject cb;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= 10; i++)
        {
            Instantiate(Ceratium);
        }
        for (int i = 0; i <= 10; i++)
        {
            Instantiate(Chaetoceros);
        }
        for (int i = 0; i <= 40; i++)
        {
            Instantiate(cb);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
