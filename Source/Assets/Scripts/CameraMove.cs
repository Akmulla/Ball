using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour 
{
	public Transform ball;
	Vector3 cameraPosition;

	void Start()
	{
		transform.position = ball.position+new Vector3(0.0f,0.0f,-3.0f);
		transform.LookAt (ball);
		cameraPosition = transform.position;
	}
	void Update () 
	{
        //transform.position = ball.position + new Vector3(0.0f, 0.0f, -3.0f);
        transform.position = ball.position + new Vector3(0.0f, 0.0f, -2.0f);


        //cameraPosition.z = ball.position.z - 3.0f;
        //transform.position = cameraPosition;
    }
}
