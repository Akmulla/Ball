using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallControl : MonoBehaviour
{
	Touch myTouch;

	void Update () 
	{
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
			myTouch = Input.GetTouch (0);
			Vector3 touchPosition = Camera.main.ScreenToWorldPoint(myTouch.position);
			touchPosition.z = 0;

			//if (!EventSystem.current.IsPointerOverGameObject(myTouch.fingerId))
			{
				
			}
		}
	}

	

}
