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
		roadSize = road.GetComponent<BoxCollider> ().size.y * road.transform.localScale.y;
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
		pool.Activate(new Vector3 (ball.transform.position.x,0.0f,edge),Quaternion.Euler(90.0f,0.0f,0.0f));
		//pool.Activate(new Vector3 (ball.transform.position.x,0.0f,ball.transform.position.z),Quaternion.Euler(90.0f,0.0f,0.0f));
		edge += roadSize;
	}
}
