using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class Scene_Changer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SceneChanger()
    {
        SceneManager.LoadScene(1);
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("in OnCollision");
        //Possibly change player to hand
        if (collider.gameObject.tag == "hand")
        {
            SceneManager.LoadScene(1);
        }
    }
}