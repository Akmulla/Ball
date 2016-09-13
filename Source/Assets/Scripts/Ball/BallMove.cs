﻿using UnityEngine;
using System.Collections;

public class BallMove : MonoBehaviour 
{
    static public BallMove ballMove;
	static public GameObject ball;
	[SerializeField]
	float startSpeed;
	float speed;
    [SerializeField]
    float minSpeed;
    [SerializeField]
	float maxSpeed;
	//[SerializeField]
	//float step;
	//[SerializeField]
	//float jump;
	[SerializeField]
	float acceleration;
    
    Rigidbody rb;
	public Vector3 movement;

	void Awake () 
	{
        ballMove = this;
		ball = gameObject;
		speed = startSpeed;
		rb = GetComponent<Rigidbody> ();
		StartCoroutine (IncreaseByTime ());
		movement = new Vector3 (0, 0, 1);
	}
		
	void Update () 
	{
        //movement.z = 1.0f;
        movement.z = speed;
        rb.velocity = movement;
	}



	public float Speed
	{
		get
		{
			return speed;
		}
		set
		{
			if (speed>maxSpeed)
			{
				speed = value;
			}
            else
                if (speed<minSpeed)
            {
                speed = minSpeed;
            }
            else
            {
                speed = value;
            }
		}
	}
	/// <summary>
	/// Set speed to basic
	/// </summary>
	public void ResetSpeed()
	{
		speed = startSpeed;
	}

	//public void MakeStep(bool moveRight)
	//{
	//	if (moveRight)
	//	{
	//		if (transform.position.x < Edges.rightEdge)
	//		{
	//			transform.position = Vector3.Lerp
	//				(transform.position, new Vector3 (transform.position.x+step, transform.position.y + jump, transform.position.z), 0.1f);
	//		}
	//	}
	//	else
	//	{
	//		if (transform.position.x > Edges.leftEdge)
	//		{
	//			transform.position = Vector3.Lerp
	//				(transform.position, new Vector3 (transform.position.x-step, transform.position.y + jump, transform.position.z), 0.1f);
	//		}
	//	}
	//	if (transform.position.y > Edges.topEdge)
	//		transform.position = new Vector3 (transform.position.x, Edges.topEdge, transform.position.z);
	//}

	IEnumerator IncreaseByTime()
	{
		while (true)
		{
			Speed += acceleration;
			yield return new WaitForSeconds (1.0f);
		}
	}

    public void SlowDown()
    {
        StartCoroutine(SlowDownCoroutine());
    }

    IEnumerator SlowDownCoroutine()
    {
        BallMove.ballMove.Speed -= 3.0f;
        yield return new WaitForSeconds(10.0f);
        BallMove.ballMove.Speed += 3.0f;
        yield return null;
    }
}
