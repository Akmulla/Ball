using UnityEngine;
using System.Collections;

public class GenerateRoad : MonoBehaviour
{
	public Transform ball;
	GameObject road;
	Pool pool;
	float roadSize;
	float edge;

	void Start ()
	{
		pool = GetComponentInChildren<Pool> ();
		ball = GameObject.Find ("Ball").GetComponent<Transform> ();
		road = pool.obj;
		roadSize = road.GetComponent<BoxCollider> ().size.x * road.transform.localScale.x;
		edge = roadSize/2;
	}

	void Update () 
	{
		if (ball.position.z > edge-roadSize)
		{
			Generate ();
		}
	}
		
	/// <summary>
	/// Generate road on the edge
	/// </summary>
	void Generate()
	{
		//Instantiate (road, new Vector3 (edge+roadSize,0.0f,0.0f),Quaternion.Euler(90.0f,0.0f,0.0f));
		pool.Activate(new Vector3 (ball.transform.position.x,0.0f,edge+roadSize),Quaternion.Euler(90.0f,0.0f,0.0f));
		edge += roadSize;
	}
}
