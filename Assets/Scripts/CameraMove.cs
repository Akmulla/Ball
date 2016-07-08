using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour 
{
	public Transform ball;

	void Update () 
	{
		transform.position = ball.position+new Vector3(-3,2,0);
		transform.LookAt (ball);
	}
}
