using UnityEngine;
using System.Collections;

public class InsideRingChangeSize : InsideRing
{
	void OnTriggerExit(Collider other)
	{
		GoThroughRing (other);
	}

	protected override void GoThroughRing (Collider other)
	{
		ballSize = other.bounds.size.x;
		Score.SetScore += (int)(100.0f / (ringSize - ballSize));
		other.gameObject.transform.localScale = new Vector3 (2.0f, 2.0f, 2.0f);
	}
}
