using UnityEngine;
using System.Collections;

public class InsideRing : MonoBehaviour
{
	void OnTriggerExit(Collider other) 
	{
		float scale = transform.parent.localScale.x;
		Score.SetScore += (int)((100.0f/scale));
	}
}
