using UnityEngine;
using System.Collections;

public class GenerateObjects : MonoBehaviour 
{
	public Pool gatePool;
    public Pool wallPool;
	Transform ball;
    public Pool[] dangerPools;
    public GateDataClass[] gateData;
    public WallDataClass[] wallData;
    public AbilityDataClass[] abilityData;
    [SerializeField] float spawnDelay;
	//[SerializeField] float minScale;
	//[SerializeField] float maxScale;

	float scale;
    float edge;

	void Start ()
	{
		ball = BallMove.ball.transform;
        edge=ball.position.z;
		StartCoroutine (SpawnGate ());
		//StartCoroutine(MassSpawn());
	}

    IEnumerator SpawnGate()
    {
        //yield return new WaitForSeconds(1.0f);
        while (true)
        {
            if (edge - ball.position.z < 100.0f)
            {
                //GameObject obj = ringPool.Activate (new Vector3 (Random.Range (ball.position.x-35.0f, ball.position.x+35.0f),
                //0.0f, ball.position.z + Random.Range (20.0f, 35.0f)), Quaternion.identity);
                float x = ball.position.z > edge ? ball.position.z : edge;
                Vector3 spawnPosition = new Vector3(Random.Range(-8.0f, 8.0f),
                        0.0f, x + Random.Range(20.0f, 30.0f));
                edge = spawnPosition.z;
                GameObject obj = gatePool.Activate(spawnPosition, Quaternion.identity);
                if (obj != null)
                {
                    obj.GetComponent<Gates>().SetData(gateData[Random.Range(0, gateData.Length)]);
                    obj.GetComponent<Gates>().SetAbility(abilityData[Random.Range(0, abilityData.Length)]);
                }

                SpawnWall();
            }
            yield return new WaitForSeconds(Random.Range(1.0f, 1.5f));
        }

    }

    void SpawnWall()
    {
        
            if (Random.value > 0.7f)
            {
                //int i = Random.Range(0, dangerPools.Length);
                float x = ball.position.z > edge ? ball.position.z : edge;
                Vector3 spawnPosition = new Vector3(Random.Range(-8.0f, 8.0f),
                        0.0f, x + Random.Range(20.0f, 30.0f));
                GameObject obj = wallPool.Activate(spawnPosition, Quaternion.identity);
            if (obj != null)
            {
                obj.GetComponent<Walls>().SetData(wallData[Random.Range(0, wallData.Length)]);
            }
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
                GameObject obj = gatePool.Activate(spawnPosition, Quaternion.identity);
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
