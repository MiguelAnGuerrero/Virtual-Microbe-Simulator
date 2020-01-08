using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonManager : MonoBehaviour
{

    public GameObject channelGrid;
    public GameObject detailModel;
    public GameObject highResModel;
    public GameObject demModel;
    public GameObject menu;
    public FlyPlayer flyPlayerScript;

    void Awake()
    {
        flyPlayerScript = GameObject.FindWithTag("Player").GetComponent<FlyPlayer>();
    }

    public void ToggleMenu()
    {
        menu.SetActive(!menu.activeSelf);
        if (!menu.activeSelf)
        {
            flyPlayerScript.FlyingAllowed = true;
        }
    }

    public void ToggleChannelGrids()
    {
        channelGrid.SetActive(!channelGrid.activeSelf);
    }

    public void TogglePhotogrammetry()
    {
        detailModel.SetActive(!detailModel.activeSelf);
    }

    public void ToggleHighRes()
    {
        highResModel.SetActive(!highResModel.activeSelf);
    }

    public void ToggleDEM()
    {
        demModel.SetActive(!demModel.activeSelf);
    }

    public void SetScale()
    {

    }

    public void TestOutput()
    {
        Debug.Log("Button Manager Test Output");
    }

}
