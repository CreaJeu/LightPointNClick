using UnityEngine;
using System.Collections;

public class AnimationTransform : MonoBehaviour
{
    public enum State
    {
        BEFORE = 0, MOVING = 1, AFTER = 2
    }

    public State state;
    public GameObject finalObject;
    public float acceleration;

	private Vector3 finalPosition;
	private Vector3 finalEulerAngles;
    private Vector3 amplitude;
    private Vector3 eulerAnglesAmplitude;
    private Vector3 speed;
    private Vector3 eulerAnglesSpeed;

    private Vector3 positionIncrement;
    private Vector3 eulerAnglesIncrement;

	void Start()
	{
        finalPosition = finalObject.transform.position;
        finalEulerAngles = finalObject.transform.eulerAngles;
        amplitude = finalObject.transform.position - this.transform.position;

        eulerAnglesAmplitude.x = this.transform.eulerAngles.x - finalObject.transform.eulerAngles.x;
        eulerAnglesAmplitude.y = this.transform.eulerAngles.y - finalObject.transform.eulerAngles.y;
        eulerAnglesAmplitude.z = this.transform.eulerAngles.z - finalObject.transform.eulerAngles.z;

        speed = Vector3.zero;
        eulerAnglesSpeed = Vector3.zero;
	}

    public void Update()
    {
        if (this.state == State.BEFORE)
        {

        }
        else if (this.state == State.MOVING)
        {
            // translation
            this.speed.x += Time.deltaTime * acceleration;
            this.speed.y += Time.deltaTime * acceleration;
            this.speed.z += Time.deltaTime * acceleration;

            positionIncrement.x = this.speed.x * Time.deltaTime * amplitude.x;
            positionIncrement.y = this.speed.y * Time.deltaTime * amplitude.y;
            positionIncrement.z = this.speed.z * Time.deltaTime * amplitude.z;

            this.transform.position += positionIncrement;

            // eulerAngles
            this.eulerAnglesSpeed.x += Time.deltaTime * acceleration;
            this.eulerAnglesSpeed.y += Time.deltaTime * acceleration;
            this.eulerAnglesSpeed.z += Time.deltaTime * acceleration;

            this.eulerAnglesIncrement.x += this.eulerAnglesSpeed.x * Time.deltaTime * eulerAnglesAmplitude.x;
            this.eulerAnglesIncrement.y += this.eulerAnglesSpeed.y * Time.deltaTime * eulerAnglesAmplitude.y;
            this.eulerAnglesIncrement.z += this.eulerAnglesSpeed.z * Time.deltaTime * eulerAnglesAmplitude.z;

            this.transform.eulerAngles += this.eulerAnglesIncrement;

            // Test end of move
            if(isMoveOver())
            {
                //this.transform.position = finalObject.transform.position;
                //this.transform.rotation = finalObject.transform.rotation;
                this.transform.position = finalPosition;
                this.transform.eulerAngles = finalEulerAngles;
                this.state = State.AFTER;
            }

        }
        else if (this.state == State.AFTER)
        {

        }
    }

    public bool isMoveOver()
    {
        bool isOver = Vector3.Dot(transform.position - finalPosition, amplitude) > 0;
            //Mathf.Sign(this.transform.position.x - this.finalObject.transform.position.x) == Mathf.Sign(amplitude.x);
        /*isOver = isOver &&
            Mathf.Sign(this.transform.position.y - this.finalObject.transform.position.y) == Mathf.Sign(amplitude.y);
        isOver = isOver &&
            Mathf.Sign(this.transform.position.z - this.finalObject.transform.position.z) == Mathf.Sign(amplitude.z);
        isOver = isOver &&
            Mathf.Sign(this.transform.eulerAngles.x - this.finalObject.transform.eulerAngles.x) == Mathf.Sign(eulerAnglesAmplitude.x);
        isOver = isOver &&
            Mathf.Sign(this.transform.eulerAngles.y - this.finalObject.transform.eulerAngles.y) == Mathf.Sign(eulerAnglesAmplitude.y);
        isOver = isOver &&
            Mathf.Sign(this.transform.eulerAngles.z - this.finalObject.transform.eulerAngles.z) == Mathf.Sign(eulerAnglesAmplitude.z);*/

        return isOver;
    }
}
