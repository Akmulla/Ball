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
		StartCoroutine (Spawn ());
		//StartCoroutine(MassSpawn());
	}

    IEnumerator Spawn()
    {
        //yield return new WaitForSeconds(1.0f);
        while (true)
        {
                //GameObject obj = ringPool.Activate (new Vector3 (Random.Range (ball.position.x-35.0f, ball.position.x+35.0f),
                //0.0f, ball.position.z + Random.Range (20.0f, 35.0f)), Quaternion.identity);
                Vector3 spawnPosition = new Vector3(Random.Range(-13.0f, 13.0f),
                    0.0f, ball.position.z + 60.0f);
                GameObject obj = ringPool.Activate(spawnPosition, Quaternion.identity);
                if (obj != null)
                {
                    //scale = Random.Range(minScale, maxScale);
                    //obj.transform.localScale = new Vector3(scale, scale, scale);
                }
            
            yield return new WaitForSeconds(Random.Range(1.0f, 1.5f));
        }

    }

    IEnumerator MassSpawn()
	{
		yield return new WaitForSeconds (1.0f);
		while (true)
		{
			int count = Random.Range (2, 4);
			for (int i=0;i<count;i++)
			{

                //GameObject obj = ringPool.Activate (new Vector3 (Random.Range (ball.position.x-35.0f, ball.position.x+35.0f),
                //0.0f, ball.position.z + Random.Range (20.0f, 35.0f)), Quaternion.identity);
                Vector3 spawnPosition=new Vector3(Random.Range(-15.0f,15.0f),
                    0.0f, ball.position.z + Random.Range(35.0f, 60.0f));
                GameObject obj = ringPool.Activate(spawnPosition, Quaternion.identity);
                if (obj != null)
				{
					//scale = Random.Range (minScale, maxScale);
					//obj.transform.localScale = new Vector3 (scale, scale, scale);
				}
			}
			yield return new WaitForSeconds (Random.Range(0.5f,1.5f));
		}
	}
}
