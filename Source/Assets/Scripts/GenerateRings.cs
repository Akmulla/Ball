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
		//StartCoroutine (Spawn ());
		StartCoroutine(MassSpawn());
	}
	
	IEnumerator Spawn()
	{
		while (true)
		{
			GameObject obj=pool.Activate(new Vector3(Random.Range(Edges.leftEdge,Edges.rightEdge),
				Random.Range(0.0f,Edges.topEdge),ball.position.z+Random.Range(20.0f,30.0f)),Quaternion.identity);
			scale = Random.Range (minScale, maxScale);
			obj.transform.localScale = new Vector3 (scale, scale, scale);

			//obj.GetComponentInChildren<InsideRing> ().IsChangingSize = Random.value>0.5f? true : false;
			yield return new WaitForSeconds (spawnDelay);
		}

	}

	IEnumerator MassSpawn()
	{
		yield return new WaitForSeconds (spawnDelay);
		while (true)
		{
			int count = Random.Range (2, 6);
			for (int i=0;i<count;i++)
			{
				GameObject obj = pool.Activate (new Vector3 (Random.Range (ball.position.x-15.0f, ball.position.x+15.0f),
					Random.Range (ball.position.y-15.0f, ball.position.y+15.0f), ball.position.z + Random.Range (20.0f, 30.0f)), Quaternion.identity);
				scale = Random.Range (minScale, maxScale);
				obj.transform.localScale = new Vector3 (scale, scale, scale);
			}
			yield return new WaitForSeconds (Random.Range(0.5f,4.0f));
		}
	}
}
