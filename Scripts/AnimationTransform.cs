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

	private Vector3 initialPosition;
	private Vector3 finalPosition;

	private Quaternion initialRotation;
	private Quaternion finalRotation;

	private float ratio;
	private float speed;

	void Start()
	{
		ratio = 0;
		speed = 0;

		initialRotation = transform.rotation;
		finalRotation = finalObject.transform.rotation;

		initialPosition = transform.position;
        finalPosition = finalObject.transform.position;
	}

    public void Update()
    {
        if (this.state == State.BEFORE)
        {

        }
        else if (this.state == State.MOVING)
		{
			speed += Time.deltaTime * acceleration;
			ratio += this.speed * Time.deltaTime;

            // Test end of move
			if (ratio >= 1) {
				//animation finished
				this.transform.position = finalPosition;
				transform.rotation = finalRotation;
				this.state = State.AFTER;
			}
			else
			{
				//interpolate according to ratio
				this.transform.position = Vector3.Lerp(initialPosition, finalPosition, ratio);
				transform.rotation = Quaternion.Lerp (initialRotation, finalRotation, ratio);
			}

        }
        else if (this.state == State.AFTER)
        {

        }
    }

}
