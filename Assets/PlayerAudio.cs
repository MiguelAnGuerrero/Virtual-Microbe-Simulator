using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class PlayerAudio : MonoBehaviour
{
    public SteamVR_Action_Boolean touchpadclick;
    public AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        touchpadclick = SteamVR_Actions._default.Teleport;
        sound.Play();
        sound.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if (touchpadclick.GetStateDown(SteamVR_Input_Sources.Any))
        {
            
            sound.UnPause();
            Debug.Log("Played Sound");
        }
        if (touchpadclick.GetStateUp(SteamVR_Input_Sources.Any))
        {
            sound.Pause();
        }
        
    }
}
