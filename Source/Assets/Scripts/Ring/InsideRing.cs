using UnityEngine;
using System.Collections;

public class InsideRing : MonoBehaviour
{
	protected float ringSize;
	protected float ballSize;

	void Start()
	{
		ringSize=GetComponent<Collider> ().bounds.size.x;
		//Debug.Log (GetComponent<Collider> ().bounds.size.x);
	}

	/*void OnTriggerEnter(Collider other)
	{
		
	}

	void OnTriggerStay(Collider other)
	{
		if (other.transform.position.z > bounds.center.z)
		{
			ballSize = GetComponent<Collider> ().bounds.size.x;
			Score.SetScore += (int)(10.0f / (ringSize - ballSize));
		}
	}*/
	void OnTriggerExit(Collider other) 
	{
		GoThroughRing (other);
		//ballSize = other.bounds.size.x;
		//Score.SetScore += (int)(100.0f / (ringSize - ballSize));
	}

	protected virtual void GoThroughRing(Collider other)
	{
		ballSize = other.bounds.size.x;
		Score.SetScore += (int)(100.0f / (ringSize - ballSize));
	}
}
