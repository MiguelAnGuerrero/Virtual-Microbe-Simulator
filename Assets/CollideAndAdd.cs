using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideAndAdd : MonoBehaviour
{
    public Light light;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    bool hasJoint;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "cb") {
            if (collision.gameObject.GetComponent<Rigidbody>() != null && !hasJoint)
            {
                gameObject.AddComponent<CharacterJoint>();
                gameObject.GetComponent<CharacterJoint>().connectedBody = collision.rigidbody;
                hasJoint = true;
                light.enabled = false;
                //gameObject.AddComponent<HingeJoint>();
                //gameObject.GetComponent<HingeJoint>().connectedBody = collision.rigidbody;
                //hasJoint = true;
                //light.enabled = false;
                //gameObject.GetComponent<HingeJoint>().maxDistance = 0.001f;
                //gameObject.GetComponent<HingeJoint>().spring = 0.1f;
                //gameObject.GetComponent<HingeJoint>().damper = 100000;
            }
        }
    }
}
