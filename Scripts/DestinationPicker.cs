using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationPicker : MonoBehaviour {
    private Collider myCollider;
    private Camera mainCamera;
    public static Vector3 destination;
    public static bool newDestination;
    public AudioSource goSFX;
    //public GameObject goSFXParent;
    /*public AudioClip goSFX;*/

	// Use this for initialization
	void Start ()
    {
        newDestination = false;
        mainCamera = Camera.allCameras[0];
        myCollider = GetComponent<Collider>();
	}

    void OnMouseDown()
    {
        //Debug.Log("zsaaszazc" + mainCamera);
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        //Debug.Log("hejejehekzelk");

        RaycastHit hit;
        if (myCollider.Raycast(ray, out hit, 100.0f))
        {
            destination = hit.point;
            //Debug.Log(destination);
            newDestination = true;

			//goSFXParent.transform.position = destination;
			goSFX.transform.position = destination;
			goSFX.Play();
			/*AudioSource.PlayClipAtPoint(goSFX, destination);*/ //ouch : new clip created and disposed each time
        }
    }
	
	// Update is called once per frame
	//void Update ()
 //   {
 //       newDestination = false;
 //       if (Input.GetMouseButtonDown(0))
 //       {
            
 //       }
	//}
}
