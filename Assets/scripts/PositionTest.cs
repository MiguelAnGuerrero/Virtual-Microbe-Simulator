using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("Center: " + gameObject.GetComponent<Renderer>().bounds.center);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
