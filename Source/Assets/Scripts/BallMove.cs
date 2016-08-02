using UnityEngine;
using System.Collections;

public class BallMove : MonoBehaviour 
{
	[SerializeField]
	float startSpeed;
	float speed;
	[SerializeField]
	float maxSpeed;
	[SerializeField]
	float step;
	[SerializeField]
	float jump;
	[SerializeField]
	float acceleration;
	Rigidbody rb;

	void Awake () 
	{
		speed = startSpeed;
		rb = GetComponent<Rigidbody> ();
		StartCoroutine (IncreaseByTime ());
	}
		
	void Update () 
	{
		rb.velocity = new Vector3 (0, 0, 1)*speed;
	}

	public float Speed
	{
		get
		{
			return speed;
		}
		set
		{
			if ((value >= 0)&&(speed<maxSpeed))
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

	public void MakeStep(bool moveRight)
	{
		if (moveRight)
		{
			if (transform.position.x < Edges.rightEdge)
			{
				transform.position = Vector3.Lerp
					(transform.position, new Vector3 (transform.position.x+step, transform.position.y + jump, transform.position.z), 0.1f);
			}
		}
		else
		{
			if (transform.position.x > Edges.leftEdge)
			{
				transform.position = Vector3.Lerp
					(transform.position, new Vector3 (transform.position.x-step, transform.position.y + jump, transform.position.z), 0.1f);
			}
		}
		if (transform.position.y > Edges.topEdge)
			transform.position = new Vector3 (transform.position.x, Edges.topEdge, transform.position.z);
	}

	IEnumerator IncreaseByTime()
	{
		while (true)
		{
			Speed += acceleration;
			yield return new WaitForSeconds (1.0f);
		}
	}
}
