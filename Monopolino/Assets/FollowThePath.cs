using UnityEngine;

public class FollowThePath : MonoBehaviour {


    //initialising variables
    public Transform[] waypoints;

    [HideInInspector]
    public int waypointIndex = 0;

    [HideInInspector]
    public bool moveAllowed = false;

	
	private void Start () {
        // setting position on start
        transform.position = waypoints[waypointIndex].transform.position;
	}
	
	// Update is called once per frame
	private void Update () {
        if (moveAllowed)
            Move();
	}

    private void Move()
    {

        //positioning the player on the waypointIndex, restarting from zero at the last box.+
        if (waypointIndex < waypoints.Length)
        {
            transform.position = waypoints[waypointIndex].transform.position;
        }
        if(waypointIndex >= waypoints.Length )
        {
            waypointIndex = 0 + waypointIndex - waypoints.Length;
            transform.position = waypoints[waypointIndex].transform.position;
        }
    }
}
