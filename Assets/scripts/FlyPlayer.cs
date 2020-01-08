using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FlyPlayer : MonoBehaviour {

    public float speed = 1.0f;
    public float rotSpeed = 1.0f;
    public float minScale = 1.0f;
    public float maxScale = 10.0f;
    public float scaleSpeed = 10.0f;
    public float startScale = 25f;
    public Transform vrCamera;
    public Text scaleText;
    public bool FlyingAllowed = true;

    private float controllerGap;
    private Vector3 flyStart;
    private float rotStartY;
    private int numGrips = 0;
    private bool firstScale = true;

	// Use this for initialization
	void Start () {
        scaleText.text = "Scale: 1m = " + transform.localScale.x.ToString("F2") + "m";

    }
	
	// Update is called once per frame
	void Update () {
        if (firstScale)
        {
            setScale(startScale);
            firstScale = false;
        }
	}

    public void Fly (Transform inputHand)
    {
        //Transform rightHand = GetComponent<Valve.VR.InteractionSystem.Player>().rightHand.transform;
        //Transform leftHand = GetComponent<Valve.VR.InteractionSystem.Player>().leftHand.transform;

        //Vector3 moveDir = inputHand.forward;
        //Debug.Log(moveDir);
        //float adjustedSpeed = transform.localScale.x * ( speed / ( (Vector3.Distance(rightHand.position, leftHand.position)) * transform.localScale.x) );
        //adjustedSpeed = adjustedSpeed * transform.localScale.x;
        //transform.position += moveDir * adjustedSpeed * Time.deltaTime;
    }

    public void setCurrentControllerGap(Transform inputHand)
    {
        numGrips++;
        //Debug.Log(numGrips);
        if (numGrips == 2)
        {
            Transform rightHand = GetComponent<Valve.VR.InteractionSystem.Player>().rightHand.transform;
            Transform leftHand = GetComponent<Valve.VR.InteractionSystem.Player>().leftHand.transform;
            controllerGap = Mathf.Abs(Vector3.Distance(rightHand.localPosition, leftHand.localPosition));
        }
    }

    public void ScalePlayer(Transform inputHand)
    {
        if (numGrips == 1)
        {
            rotatePlayer(inputHand);
        }
        if (numGrips == 2)
        {
            Transform rightHand = GetComponent<Valve.VR.InteractionSystem.Player>().rightHand.transform;
            Transform leftHand = GetComponent<Valve.VR.InteractionSystem.Player>().leftHand.transform;

            float currentGap = Mathf.Abs(Vector3.Distance(rightHand.localPosition, leftHand.localPosition));
            float updateGap = (( currentGap - controllerGap) * scaleSpeed);

            //Debug.Log("UPDATE GAP: " + updateGap);

            if( Mathf.Abs(updateGap) > 0.05f)
            {
                float newScale = transform.localScale.x - updateGap;
                if (newScale < minScale)
                {
                    transform.localScale = new Vector3(minScale, minScale, minScale);
                }
                else if (newScale > maxScale)
                {
                    transform.localScale = new Vector3(maxScale, maxScale, maxScale);
                }
                else
                {
                    // transform.localScale = new Vector3(transform.localScale.x - updateGap, transform.localScale.y - updateGap, transform.localScale.z - updateGap);
                    Vector3 updateScale = new Vector3(transform.localScale.x - updateGap, transform.localScale.y - updateGap, transform.localScale.z - updateGap);
                    ScaleAround(transform, vrCamera, updateScale);
                    //ScaleAround(transform, (rightHand.localPosition + leftHand.localPosition) / 2, updateScale);
                    controllerGap = currentGap;
                }
            }

            
        }
    }

    public void ScaleAround(Transform target, Transform pivot, Vector3 newScale)
    {
        Vector3 A = target.localPosition;
        Vector3 B = pivot.position;
        //Vector3 B = pivot;

        Vector3 C = A - B; // diff from object pivot to desired pivot/origin

        float RS = newScale.x / target.localScale.x; // relative scale factor

        // calc final position post-scale
        Vector3 FP = B + C * RS;

        // finally, actually perform the scale/translation
        target.localScale = newScale;
        target.localPosition = FP;

        scaleText.text = "Scale: 1m = " + newScale.x.ToString("F2") + "m";
}

    public void resetScale()
    {
        ScaleAround(transform, vrCamera, new Vector3(1.0f, 1.0f, 1.0f));
        // transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }

    public void setScale(float newScale)
    {
        ScaleAround(transform, vrCamera, new Vector3(newScale, newScale, newScale));
    }

    public void releaseGrips ()
    {
        numGrips = 0;
    }

    public void setFlyStart(Transform inputHand)
    {
        flyStart = inputHand.position;
    }

    public void flyPlayer(Transform inputHand)
    {

        if (FlyingAllowed)
        {
            Vector3 distVec = inputHand.localPosition - flyStart;
            float dist = Vector3.Distance(inputHand.localPosition, flyStart);

            //if (dist > 0.2)
            //{
            //transform.position += (inputHand.position - flyStart) * 0.25f;
            //}

            //else
            //{
            Vector3 moveDir = inputHand.forward;
            float adjustedSpeed = speed * transform.localScale.x;
            transform.position += moveDir * adjustedSpeed * Time.deltaTime;
            //}



            //Vector3 moveDir = inputHand.forward;
            //float dist = Vector3.Distance(inputHand.localPosition, flyStart);

            ////Move Backwards
            //if (inputHand.localPosition.z < flyStart.z && dist > 0.05f)
            //{
            //    transform.position -= moveDir * dist * Time.deltaTime;
            //}
            //else
            //{
            //    transform.position += moveDir * dist * Time.deltaTime;
            //}


            //float adjustedSpeed = transform.localScale.x * (speed / ((Vector3.Distance(inputHand.localPosition, flyStart)) * transform.localScale.x));
            //float adjustedSpeed = speed * transform.localScale.x;
            //transform.position += moveDir * adjustedSpeed * Time.deltaTime;
        }



    }

    public void setRotStart(Transform inputHand)
    {
        rotStartY = inputHand.localEulerAngles.y;
    }

    public void rotatePlayer(Transform inputHand)
    {

        if (numGrips == 1)
        {
            //Debug.Log("Starting Rotation: " + rotStartY);
            float currRotY = inputHand.localEulerAngles.y;
            //Debug.Log("Current Rotation: " + currRotY);

            float diffRot = (currRotY - rotStartY);
            transform.RotateAround(vrCamera.position, Vector3.up, (-1 * diffRot / rotSpeed));
            rotStartY = currRotY;
        }
        

        //if (hand.controller.GetPress(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad))
        //{

        //    if (hand.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip))
        //    {
        //        showRotOverlay = !showRotOverlay;
        //        rotOverlay.SetActive(!rotOverlay.active);
        //    }

        //    //Debug.Log("Starting Rotation: " + startRotationY);
        //    float currentRotationY = hand.transform.localEulerAngles.y;
        //    //Debug.Log("Current Rotation: " + currentRotationY);
        //    float trackpadRotDiff_y = (currentRotationY - startRotationY);
        //    //Debug.Log("Rotation Difference: " + trackpadRotDiff_y);

        //    player.transform.RotateAround(vrCamera.transform.position, Vector3.up, (-1 * trackpadRotDiff_y / rotSpeed));

        //    startRotationY = currentRotationY;
        //    //Debug.Log("\n\n");
        //}
    }


}
