using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kbrevisTeleport : MonoBehaviour
{
    //public Vector3 newposition;
    // Start is called before the first frame update
    public Vector3 newposition;
    void Start()
    {
        newposition = new Vector3();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            newposition.x = Random.Range(-100, 100);
            newposition.y = Random.Range(-100, 100);
            newposition.z = Random.Range(-100, 100);
            other.gameObject.transform.position = newposition;
           
            //transform.position = newposition;
        }
    }
}
