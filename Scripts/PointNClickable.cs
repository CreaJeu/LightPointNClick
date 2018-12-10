using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointNClickable : MonoBehaviour {
    public static PointNClickable clicked;

    void OnMouseDown()
    {
        clicked = this;
    }

    public virtual void Interact()
    {
    
    }

    public virtual void PreClick()
    {
        
    }
}
