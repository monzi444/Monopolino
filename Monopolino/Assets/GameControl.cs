using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameControl : MonoBehaviour {


    //initialising variables
    private static GameObject player1, player2;

    public static int diceSideThrown = 0;

    public static GameObject dice1, dice2;

    //whosTurn: 1->Player1; 2->Player2
    private static int whosTurn = 1;

    // Use this for initialization
    void Start () {

        //taking variable references
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        dice1 = GameObject.Find("Dice1");
        dice2 = GameObject.Find("Dice2");
    }

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
}
