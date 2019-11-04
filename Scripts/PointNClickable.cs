using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointNClickable : MonoBehaviour {
    public static PointNClickable clicked;

    void OnMouseDown()
    {
        clicked = this;
        DestinationPicker.destination = transform.position;
        DestinationPicker.newDestination = true;
    }

	public virtual AudioSource Interact()
    {
		return null;
    }

    public virtual void PreClick()
    {
        
    }
}
