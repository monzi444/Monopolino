using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;
using Random = System.Random;

public class Imprevisti : MonoBehaviour
{
    private static GameObject player;
    

    private static GameObject control;

 

    // Start is called before the first frame update
    void Start()
    {
        control = GameObject.Find("GameControl");

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        player = collision.gameObject;
        DrawCard(player);
    }

    private void DrawCard(GameObject player)
    {
        Random r = new Random();
        ImprevistoCard card = control.GetComponent<GameControl>().cardsImprevisti[r.Next(0,control.GetComponent<GameControl>().cardsImprevisti.Count())];
        card.action(player);
    }
}
