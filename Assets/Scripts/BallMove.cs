using UnityEngine;
using System.Collections;

public class BallMove : MonoBehaviour 
{
	public float startSpeed;
	public float acceleration;
	static float speed;
	Rigidbody rb;

	void Start () 
	{
		speed = startSpeed;
		rb = GetComponent<Rigidbody> ();
		StartCoroutine (IncreaseByTime ());
	}
		
	void Update () 
	{
		rb.velocity = new Vector3 (1, 0, 0)*speed;
	}

	public static float Speed
	{
		get
		{
			return speed;
		}
		set
		{
			if (value >= 0)
			{
				speed = value;
			}
		}
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
