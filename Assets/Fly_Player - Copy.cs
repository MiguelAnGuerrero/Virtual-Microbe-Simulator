using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class Fly_Player : MonoBehaviour
{
   public GameObject controller;
    public float speed;
    public SteamVR_Action_Boolean touchpadclick;
    //public SteamVR_Action_Vector2 touchpad;
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
        if(touchpadclick.GetState(SteamVR_Input_Sources.Any)) {
            transform.position = transform.position + controller.transform.forward * speed * Time.deltaTime;
        }
    }
}
