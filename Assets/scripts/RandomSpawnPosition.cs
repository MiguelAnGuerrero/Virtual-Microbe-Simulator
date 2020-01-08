using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Vector3 newposition = new Vector3();
        newposition.x = Random.Range(-100, 100);
        newposition.y = Random.Range(-100, 100);
        newposition.z = Random.Range(-100, 100);
        transform.position = newposition;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
