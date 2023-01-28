using System.Collections;
using UnityEngine;
using System.Threading;
public class Dice : MonoBehaviour {

    //initialising variables
    public Sprite[] diceSides;
    private SpriteRenderer rend;
    private GameObject control;

	// Use this for initialization
	private void Start () {
        //taking variable references
        rend = GetComponent<SpriteRenderer>();
        rend.sprite = diceSides[5];
        control = GameObject.Find("GameControl");
	}

    private void OnMouseDown()
    { 
        //starting the roll coroutine on click
        control.GetComponent<GameControl>().StartCoroutine("Roll");
    }

    //generating random value
    public int RollTheDice()
    {
        int randomDiceSide = 0;    
        randomDiceSide = Random.Range(0, 6);
        rend.sprite = diceSides[randomDiceSide];
        return randomDiceSide +1;
    }

    //returning 15 times a random side
    private IEnumerator RollAnimation()
    {
        for(int i = 0; i<=15; i++)
        {
            int side = Random.Range(0, 6);
            rend.sprite = diceSides[side];
            yield return new WaitForSeconds(0.05f);
        }
    }
}
