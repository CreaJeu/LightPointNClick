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

	// Use this for initialization
	void Start () {
        state = State.READY;
        //GetComponent<NavMeshAgent>().destination = new Vector3(10,0,10);
	}
	
	// Update is called once per frame
	void Update () {
        if (DestinationPicker.newDestination) {
            Debug.Log("dest ? " + DestinationPicker.newDestination + " " + DestinationPicker.destination);
            GetComponent<NavMeshAgent>().destination = DestinationPicker.destination;
        }
	}
}
