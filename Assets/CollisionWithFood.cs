using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithFood : MonoBehaviour
{
    public GameObject player;
    public AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] players;
        players = GameObject.FindGameObjectsWithTag("player");
        player = players[0];
        //followDistance = Random.Range(10, 25);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "food")
        {
            Destroy(collider.gameObject);

            player.GetComponent<Flying>().maxspeed++;
            player.GetComponent<Flying>().speedchange+= 0.01f;
            sound.Play();
            Debug.Log("ATE FOOD");
           
        }
    }
}
