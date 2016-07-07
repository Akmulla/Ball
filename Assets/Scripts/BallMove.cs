using UnityEngine;
using System.Collections;

public class BallMove : MonoBehaviour 
{
	public float speed;
	Rigidbody rb;
	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () 
	{
		rb.velocity = new Vector3 (1, 0, 0)*speed;
	}
}
