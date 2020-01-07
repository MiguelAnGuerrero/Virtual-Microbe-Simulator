using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kbrevisAI : MonoBehaviour
{
    public GameObject player;
    public float movementSpeed;
    public Vector3 rotations;
    public Quaternion before;
    public Quaternion after;
    public bool followPlayer;
    public float randomx = 0;
    public float randomy = 0;
    public float randomz = 0;
    public int timer;
    public int maxtime = 60;
    public GameObject[] foodArray;
    public float followDistance;
   // public float movementSpeed;
    public Vector3 scaleChange;
    public float baseScale;
    public Vector3 foodScale;
    public float foodScaleAmount;
    // Start is called before the first frame update
    void Start()
    {
        baseScale = Random.Range(4f, 8f);
        // baseScale = 1;
        scaleChange.x = transform.localScale.x * baseScale; //+ Random.Range(0.00125f, 0.0025f);
        scaleChange.y = transform.localScale.y * baseScale; //+ Random.Range(0.00125f, 0.0025f);
        scaleChange.z = transform.localScale.z * baseScale; //+ Random.Range(0.00125f, 0.0025f);
        this.transform.localScale = scaleChange;
        movementSpeed = 0; //* this.gameObject.transform.localScale.z / 200;//* this.gameObject.transform.localScale.z;//* 50;
        //Debug.Log(this.gameObject.transform.localScale.z);
        GameObject[] players;
        players = GameObject.FindGameObjectsWithTag("player");
        player = players[0];
        followDistance = Random.Range(10, 25);
        // foodArray = GameObject.FindGameObjectsWithTag("food");
    }
    public GameObject FindClosestFood()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("food");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, this.gameObject.transform.position);
        if (dist < 20)
        {
            Vector3 newposition = new Vector3();
            newposition.x = Random.Range(-100, 100);
            newposition.y = Random.Range(-100, 100);
            newposition.z = Random.Range(-100, 100);
            transform.position = newposition;
        }
        if (dist < followDistance)
        {
            followPlayer = true;

        }
        else
        {
            followPlayer = true;
        }
        if (followPlayer)
        {
            if (timer > maxtime)
            {
                randomx = Random.Range(-10, 10);
                randomy = Random.Range(-10, 10);
                randomz = Random.Range(-10, 10);
                maxtime = Random.Range(5, 15);
                before = transform.rotation;
                transform.LookAt(player.transform);
                after = transform.rotation;
                rotations = after.eulerAngles;
                transform.rotation = before;
                after = Quaternion.Euler(rotations.x + randomx, rotations.y + randomy, rotations.z + randomz);
                //transform.rotation = Quaternion.Slerp(before,after,8.0f * Time.deltaTime);
                transform.rotation = after;
                movementSpeed = Random.Range(0.0f, 1.0f);
                //transform.LookAt(player.transform);

                timer = 0;
            }
            else
            {
                timer++;
            }

            transform.position += transform.forward * movementSpeed * Time.deltaTime;
        }
        // Find food
        else
        {
            GameObject nearestFood = FindClosestFood();
            //transform.LookAt(nearestFood.transform);
            //transform.position += transform.forward * movementSpeed * Time.deltaTime;


            if (timer > maxtime)
            {
                randomx = Random.Range(-40, 40);
                randomy = Random.Range(-40, 40);
                randomz = Random.Range(-40, 40);
                maxtime = Random.Range(30, 120);
                before = transform.rotation;
                transform.LookAt(nearestFood.transform);
                after = transform.rotation;
                rotations = after.eulerAngles;
                transform.rotation = before;
                after = Quaternion.Euler(rotations.x + randomx, rotations.y + randomy, rotations.z + randomz);
                //transform.rotation = Quaternion.Slerp(before,after,8.0f * Time.deltaTime);
                transform.rotation = after;
                movementSpeed = Random.Range(0.0f, 0.0f);
                //transform.LookAt(player.transform);

                timer = 0;
            }
            else
            {
                timer++;
            }

            transform.position += transform.forward * movementSpeed * Time.deltaTime;
        }
    }


    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "food")
        {
            //Destroy(collider.gameObject);
           // transform.localScale += new Vector3(.1f, .1f, .1f);
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {
            //Vector3 newposition = new Vector3();
            //newposition.x = Random.Range(-100, 100);
            //newposition.y = Random.Range(-100, 100);
            //newposition.z = Random.Range(-100, 100);
            //transform.position = newposition;
            //Destroy(collider.gameObject);
            // transform.localScale += new Vector3(.1f, .1f, .1f);
        }

    }
}
