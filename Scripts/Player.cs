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
            Debug.Log("dest ? " + DestinationPicker.newDestination + " " + DestinationPicker.destination);
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
                    PointNClickable.clicked.Interact();
                    PointNClickable.clicked = null;
                }
            }
        }
	}
}
