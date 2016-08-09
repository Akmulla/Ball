using UnityEngine;
using System.Collections;

public class GenerateRings : MonoBehaviour 
{
	public static Pool ringPool;
	Transform ball;

	[SerializeField] float spawnDelay;
	[SerializeField] float minScale;
	[SerializeField] float maxScale;

	float scale;

	void Start ()
	{
		ringPool = GetComponentInChildren<Pool> ();
		ball = BallMove.ball.transform;
		//StartCoroutine (Spawn ());
		StartCoroutine(MassSpawn());
	}
	
	IEnumerator Spawn()
	{
		while (true)
		{
			GameObject obj=ringPool.Activate(new Vector3(Random.Range(Edges.leftEdge-5.0f,Edges.rightEdge+5.0f),
				Random.Range(Edges.botEdge-5.0f,Edges.topEdge+5.0f),ball.position.z+Random.Range(20.0f,30.0f)),Quaternion.identity);
			scale = Random.Range (minScale, maxScale);
			obj.transform.localScale = new Vector3 (scale, scale, scale);

			//obj.GetComponentInChildren<InsideRing> ().IsChangingSize = Random.value>0.5f? true : false;
			yield return new WaitForSeconds (spawnDelay);
		}

	}

	IEnumerator MassSpawn()
	{
		yield return new WaitForSeconds (1.0f);
		while (true)
		{
			int count = Random.Range (1, 3);
			for (int i=0;i<count;i++)
			{
				GameObject obj = ringPool.Activate (new Vector3 (Random.Range (ball.position.x-35.0f, ball.position.x+35.0f),
					Random.Range (ball.position.y-35.0f, ball.position.y+35.0f), ball.position.z + Random.Range (20.0f, 35.0f)), Quaternion.identity);
				if (obj != null)
				{
					scale = Random.Range (minScale, maxScale);
					obj.transform.localScale = new Vector3 (scale, scale, scale);
				}
			}
			yield return new WaitForSeconds (Random.Range(0.2f,0.5f));
		}
	}
}
