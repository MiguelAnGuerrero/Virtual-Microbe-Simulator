using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enable_Node : MonoBehaviour
{
    // Start is called before the first frame update
    public int count;
    public GameObject[] cbs;
    public GameObject[] cbsReversed;
    public MeshRenderer mesh;
    public CapsuleCollider capsule;
    public GameObject player;

    void Start()
    {
        cbs= GameObject.FindGameObjectsWithTag("cb");
        GameObject[] players;
        players = GameObject.FindGameObjectsWithTag("player");
        player = players[0];
        //for (int i = cbs.Length-1; i >= 0;i--)
        //{

        //    Debug.Log("cb: "+ cbs[i].name);
        //    cbsReversed[cbs.Length-i] = cbs[i];
        //}
        //for (int i = 0; i < cbsReversed.Length; i++)
        //{
        //    Debug.Log("cbR: " + cbsReversed[i].name);
        //}


    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void OnCollisionEnter(Collision collision)
    {
        //Possibly change player to hand
        if (collision.gameObject.tag == "player")
        {
            //Store Count in Player, access using 
            mesh = cbs[cbs.Length - player.GetComponent<cbCounter>().count - 1].GetComponent<MeshRenderer>();
            capsule = cbs[cbs.Length - player.GetComponent<cbCounter>().count - 1].GetComponent<CapsuleCollider>();
            mesh.enabled = true;
            capsule.enabled = true;
            cbs[count].SetActive(true);
            player.GetComponent<cbCounter>().count++;
            Debug.Log("Count:" + player.GetComponent<cbCounter>().count);
            Destroy(this.gameObject);
            //count++;
        }
    }
}
