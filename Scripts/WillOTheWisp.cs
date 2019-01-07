using UnityEngine;
using System.Collections;

public class WillOTheWisp : MonoBehaviour
{
    float timeTillRand;
    Vector3 acceleration;
    Vector3 currSpeed;
    Vector3 newTarget;
    Vector3 oldTarget;

    float getSpeed()
    {
        return 20f;
    }

    Vector3 getPosMin()
    {
        return new Vector3(0,2,0);
    }

    Vector3 getPosMax()
    {
        return new Vector3(10,10,10);
    }

    Vector3 getTargetRd()
    {
        float x = Random.Range(getPosMin().x, getPosMax().x);
        float y = Random.Range(getPosMin().y, getPosMax().y);
        float z = Random.Range(getPosMin().z, getPosMax().z);

        return new Vector3(x, y, z);
    }

	// Use this for initialization
	void Start()
	{
        currSpeed = Vector3.zero;
        acceleration = Vector3.zero;
        timeTillRand = -1;
	}

	// Update is called once per frame
	void Update()
    {
        float dt = Time.deltaTime;
        // changement de cible
        if (timeTillRand <= 0)
        {
            oldTarget = transform.position;
            newTarget = getTargetRd();
            Debug.Log("changement de cible " + newTarget.x + " " + newTarget.y + " " + newTarget.z);
            timeTillRand = Vector3.Distance(oldTarget, newTarget) / getSpeed();
            Vector3 gap = newTarget - oldTarget;
            acceleration = (-1 / (timeTillRand * timeTillRand)) * (timeTillRand * currSpeed - gap);
        }

        currSpeed += acceleration * dt;
        transform.position += currSpeed * dt;
        timeTillRand -= dt;
	}
}
