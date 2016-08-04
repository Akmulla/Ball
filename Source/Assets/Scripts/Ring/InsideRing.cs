using UnityEngine;
using System.Collections;

public class InsideRing : MonoBehaviour
{
	float ringSize;
	float ballSize;
	bool isChangingSize=false;
	float coeff;

	void Start()
	{
		ringSize=GetComponent<Collider> ().bounds.size.x;
		coeff = Random.Range (0.5f, 2.0f);
		//Debug.Log (GetComponent<Collider> ().bounds.size.x);
	}
	public bool IsChangingSize
	{
		get
		{
			return isChangingSize;
		}
		set
		{
			isChangingSize = value;
		}
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

	void GoThroughRing(Collider other)
	{
		ballSize = other.bounds.size.x;
		Score.SetScore += (int)(100.0f * (ballSize/ringSize));

		if (isChangingSize)
		{
			other.gameObject.transform.localScale = new Vector3 (coeff, coeff, coeff);
		}
	}
}
