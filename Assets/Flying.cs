using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class Flying : MonoBehaviour
{
    public GameObject controller;
    public float speed;
    public SteamVR_Action_Boolean touchpadclick;
    //public SteamVR_Action_Vector2 touchpad;
    public float speedchange;
    public float maxspeed;
    public float minspeed;
    // Start is called before the first frame update
    void Start()
    {
        touchpadclick = SteamVR_Actions._default.Teleport;

        //public Vector3 playerPos();


    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = transform.position + player.main.transform.forward * 100 * Time.deltaTime;
        if (touchpadclick.GetState(SteamVR_Input_Sources.Any))
        {
            if (speed < maxspeed)
            {
                speed = speed + speedchange;
            }

            transform.position = transform.position + controller.transform.forward * speed * Time.deltaTime;
        }
        else if (speed > minspeed)
        {
            speed = speed - speedchange;
            transform.position = transform.position + controller.transform.forward * speed * Time.deltaTime;
        }
    }
    
}
