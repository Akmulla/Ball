using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour 
{
	public Transform ball;

	void Update () 
	{
		transform.position = ball.position+new Vector3(0,2,-3);
		transform.LookAt (ball);
	}
}
