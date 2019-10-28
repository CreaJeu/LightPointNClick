using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour {
    enum State
    {
        READY, WALKING
    };

    State state;
    NavMeshAgent navMeshAgent;

	public bool isWalking()
	{
		return state == State.WALKING;
	}
		

	// Use this for initialization
	void Start ()
    {
        state = State.READY;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (DestinationPicker.newDestination)
        {
            state = State.WALKING;
            // Debug.Log("dest ? " + DestinationPicker.newDestination + " " + DestinationPicker.destination);
            navMeshAgent.destination = DestinationPicker.destination;
        }
        if (state == State.WALKING)
        {
            NavMeshPathStatus status = navMeshAgent.pathStatus;
            float dist = navMeshAgent.remainingDistance;
            if (!navMeshAgent.pathPending &&
                status == NavMeshPathStatus.PathComplete &&
                dist <= navMeshAgent.stoppingDistance * 2)
            {
                state = State.READY;
                if (PointNClickable.clicked != null)
                {
                    PointNClickable.clicked.PreClick();
					AudioSource sfx = PointNClickable.clicked.Interact();
					if (sfx != null)
					{
						sfx.transform.position = PointNClickable.clicked.transform.position;
						sfx.Play();
					}
                    PointNClickable.clicked = null;
                }
            }
        }
	}
}
