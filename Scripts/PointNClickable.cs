using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointNClickable : MonoBehaviour {
    public static PointNClickable clicked;

    void OnMouseDown()
    {
        Interact();
    }

    public virtual void Interact()
    {
    
    }

    public virtual void PreClick()
    {
        
    }
}
