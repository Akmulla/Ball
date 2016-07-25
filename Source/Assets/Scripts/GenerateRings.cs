using UnityEngine;
using System.Collections;

public class GenerateRings : MonoBehaviour 
{
	Pool pool;
	Transform ball;
	[SerializeField] float spawnDelay;

	void Start ()
	{
		pool = GetComponentInChildren<Pool> ();
		ball = GameObject.Find ("Ball").transform;
		StartCoroutine (Spawn ());
	}
	
	IEnumerator Spawn()
	{
		while (true)
		{
			pool.Activate(new Vector3(Random.Range(Edges.leftEdge,Edges.rightEdge),
				Random.Range(0.0f,Edges.topEdge),ball.position.z+Random.Range(5.0f,7.0f)),Quaternion.Euler(90.0f,0.0f,0.0f));
			yield return new WaitForSeconds (spawnDelay);
		}

	}
}
