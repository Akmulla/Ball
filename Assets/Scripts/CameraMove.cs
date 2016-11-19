using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
    public Transform ball;
    [SerializeField] Vector3 cameraPosition;

	void Start()
	{
		transform.position = ball.position+cameraPosition;
		transform.LookAt (ball);
		cameraPosition = transform.position;
	}
	void Update () 
	{
        transform.position = new Vector3(
            cameraPosition.x,cameraPosition.y,cameraPosition.z+ball.position.z);
        //transform.position = ball.position + cameraPosition;
        

        //cameraPosition.z = ball.position.z - 3.0f;
        //transform.position = cameraPosition;
    }
}
