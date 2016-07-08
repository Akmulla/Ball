using UnityEngine;
using System.Collections;

public class GenerateRoad : MonoBehaviour
{
	public Transform ball;
	public GameObject road;
	float roadSize;
	float edge;

	void Start ()
	{
		ball = GameObject.Find ("Ball").GetComponent<Transform> ();
		roadSize = road.GetComponent<BoxCollider> ().size.x * road.transform.localScale.x;
		edge = roadSize/2;
	}

	void Update () 
	{
		if (ball.position.x > edge-roadSize)
		{
			Generate ();
		}
	}

	void Generate()
	{
		Instantiate (road, new Vector3 (edge+roadSize,0.0f,0.0f),Quaternion.Euler(90.0f,0.0f,0.0f));
		edge += roadSize;
	}
}
