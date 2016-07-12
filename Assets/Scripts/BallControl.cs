﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallControl : MonoBehaviour
{
	Touch myTouch;
	bool moveRight;
	BallMove ballMove;

	void Start()
	{
		ballMove = GetComponent<BallMove> ();
	}

	void Update () 
	{
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
			myTouch = Input.GetTouch (0);
			Vector3 touchPosition = Camera.main.ScreenToWorldPoint(myTouch.position);
			//Debug.Log (touchPosition);
			//Debug.Log(myTouch.position);
			//if (!EventSystem.current.IsPointerOverGameObject(myTouch.fingerId))
			{
				//if (touchPosition.z > transform.position.z)
				if (myTouch.position.x < Camera.main.pixelWidth/2.0f)
				{
					moveRight = true;
				}
				else
				{
					moveRight = false;
				}
				ballMove.MakeStep (moveRight);
			}
		}
	}

	

}
