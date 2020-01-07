using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
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
    // Start is called before the first frame update
    void Start()
    {
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
        if (dist < followDistance)
        {
            followPlayer = true;

        }
        else
        {
            followPlayer = true;
        }
        if (followPlayer) {
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
                movementSpeed = Random.Range(0.0f, 5.0f);
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
                movementSpeed = Random.Range(0.0f, 5.0f);
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
        if (collider.gameObject.tag == "food") {
            Destroy(collider.gameObject);
            transform.localScale += new Vector3(.1f,.1f,.1f);
        }
        
    }
}
