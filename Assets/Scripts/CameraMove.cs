using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour 
{
	public GameObject ball;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = ball.transform.position+new Vector3(-3,3,0);
	}
}
