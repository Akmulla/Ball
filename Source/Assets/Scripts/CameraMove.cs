using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour 
{
	public Transform ball;

	void Update () 
	{
		transform.position = ball.position+new Vector3(0.0f,0.0f,-3.0f);
		transform.LookAt (ball);
	}
}
