using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyAI : MonoBehaviour
{
    public float movementSpeed;
    public Vector3 scaleChange;
    public float baseScale;
    public Vector3 foodScale;
    public float foodScaleAmount;
    public float timer = 50;
    // Start is called before the first frame update
    void Start()
    {
         baseScale = Random.Range(0.25f, 4f);
       // baseScale = 1;
        scaleChange.x = transform.localScale.x * baseScale; //+ Random.Range(0.00125f, 0.0025f);
        scaleChange.y = transform.localScale.y * baseScale; //+ Random.Range(0.00125f, 0.0025f);
        scaleChange.z = transform.localScale.z * baseScale; //+ Random.Range(0.00125f, 0.0025f);
        this.transform.localScale = scaleChange;
       // movementSpeed = 2 * this.gameObject.transform.localScale.z * 50;
        

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
        GameObject nearestFood = FindClosestFood();
        if (timer < 0)
        {
            //transform.LookAt(nearestFood.transform);
            //timer = Random.Range(10,100);
            
        }
        else
        {
            timer--;
        }
        //transform.position += transform.forward * movementSpeed * Time.deltaTime;
        transform.LookAt(nearestFood.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, nearestFood.transform.position, movementSpeed*Time.deltaTime);
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "food")
        {
            Debug.Log("collision");
            Destroy(collider.gameObject);
            foodScale.x = transform.localScale.x * 1.1f;
            foodScale.y = transform.localScale.y * 1.1f;
            foodScale.z = transform.localScale.z * 1.1f;
            transform.localScale = foodScale;
        }

    }
}
