using UnityEngine;
using System.Collections;

public class GenerateRings : MonoBehaviour 
{
	Pool pool;
	Transform ball;
	[SerializeField] float spawnDelay;
	[SerializeField] float minScale;
	[SerializeField] float maxScale;

	float scale;

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
			GameObject obj=pool.Activate(new Vector3(Random.Range(Edges.leftEdge,Edges.rightEdge),
				Random.Range(0.0f,Edges.topEdge),ball.position.z+Random.Range(20.0f,30.0f)),Quaternion.identity);
			scale = Random.Range (minScale, maxScale);
			obj.transform.localScale = new Vector3 (scale, scale, scale);
			yield return new WaitForSeconds (spawnDelay);
		}

	}
}
