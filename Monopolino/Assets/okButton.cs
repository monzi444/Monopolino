using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class okButton : MonoBehaviour
{
    GameObject control;
    // Start is called before the first frame update
    void Start()
    {
        control = GameObject.Find("GameControl");
    }

    private void OnMouseDown()
    {
        Thread.Sleep(100);
        control.GetComponent<GameControl>().ActivateALl();
    }
}
