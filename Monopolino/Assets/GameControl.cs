using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;
using Random = System.Random;


//class CartaImprevisto containing card datas, the Action delegates contains what to do on card draw
public class ImprevistoCard
{
    public int id;
    public string name;
    public string description;
    public Delegate Action;

    public ImprevistoCard(int id, string name, string description, Delegate action)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.Action = action;
    }
}


//KeyCaluePair with infos of the cards (serializable in inspector)
[Serializable]
public class info
{
    public string name;
    public string description;
}

public class GameControl : MonoBehaviour {


    //initialising variables

    #region gameObjects
    private static GameObject player1, player2;

    public static GameObject dice1, dice2;
    #endregion


    #region dice roll and player movement
    //whosTurn: 1->Player1; 2->Player2
    private static int whosTurn = 1;
    
    public static int diceSideThrown = 0;
    #endregion

    #region imprevisti
    //list of info, contains all the cards info
    public List<info> cardsInfoImprevisti = new List<info>();

    //list of cards
    public List<ImprevistoCard> cards = new List<ImprevistoCard>();
  
    delegate void Action(GameObject player);
    #endregion
    // Use this for initialization
    void Start () {

        //taking variable references
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        dice1 = GameObject.Find("Dice1");
        dice2 = GameObject.Find("Dice2");



        //on start filling each card with their info
        //in this method are established delegates actions (what to do on card draw)
        for (int i = 0; i < cardsInfoImprevisti.Count(); i++)
        {
            switch (i)
            {
                case 0:
                    Action action0 = delegate (GameObject player) {

                    };
                    cards.Add(new ImprevistoCard(i, cardsInfoImprevisti[i].name, cardsInfoImprevisti[i].description, action0));
                    break;
                case 1:
                    Action action1 = delegate (GameObject player) {

                    };
                    cards.Add(new ImprevistoCard(i, cardsInfoImprevisti[i].name, cardsInfoImprevisti[i].description, action1));
                    break;
                case 2:
                    Action action2 = delegate (GameObject player) {

                    };
                    cards.Add(new ImprevistoCard(i, cardsInfoImprevisti[i].name, cardsInfoImprevisti[i].description, action2));
                    break;
            }

        }
    }


    #region dice roll and player movement
    //called on dice click
    public IEnumerator Roll()
    {
        //starting the roll animation coroutine
        //https://docs.unity3d.com/Manual/Coroutines.html
        Coroutine coroutine1 =  dice1.GetComponent<Dice>().StartCoroutine("RollAnimation");
        Coroutine coroutine2 = dice2.GetComponent<Dice>().StartCoroutine("RollAnimation");


        //waiting for coroutines end
        yield return coroutine1;
        yield return coroutine2;

        //taking dice random value
        int res1 = dice1.GetComponent<Dice>().RollTheDice();
        int res2 = dice2.GetComponent<Dice>().RollTheDice();
        
        //adding dice values
        diceSideThrown = res1 + res2;


        //moving the player whose turn it is
        if (whosTurn == 1)
        {
            MovePlayer(1);
        } else if (whosTurn == -1)
        {
            MovePlayer(2);
        }

        //changing whosTurn
        whosTurn *= -1;
    }

    public static void MovePlayer(int playerToMove)
    {

        switch (playerToMove) { 
            case 1:

                //setting new waypointIndex
                player1.GetComponent<FollowThePath>().waypointIndex += diceSideThrown;

                //allowing player movement
                player1.GetComponent<FollowThePath>().moveAllowed = true;
                break;

            case 2:
                //setting new waypointIndex
                player2.GetComponent<FollowThePath>().waypointIndex += diceSideThrown;

                //allowing player movement
                player2.GetComponent<FollowThePath>().moveAllowed = true;
                break;
        }
    }
    #endregion
}
