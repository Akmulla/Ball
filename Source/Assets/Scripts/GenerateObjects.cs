using UnityEngine;
using System.Collections;

public class GenerateObjects : MonoBehaviour 
{
	public Pool gatePool;
    public Pool wallPool;
    public Pool dangerZonePool;
	Transform ball;
    public GateDataClass[] gateData;
    public WallDataClass[] wallData;
    public AbilityDataClass[] abilityData;
    [SerializeField] float spawnDelay;

	float scale;
    float edge;

	void Start ()
	{
		ball = BallMove.ball.transform;
        edge=ball.position.z;
		StartCoroutine (SpawnGate ());
	}

    IEnumerator SpawnGate()
    {
        //yield return new WaitForSeconds(1.0f);
        while (true)
        {
            if (edge - ball.position.z < 100.0f)
            {
                float x = ball.position.z > edge ? ball.position.z : edge;
                Vector3 spawnPosition = new Vector3(Random.Range(-8.0f, 8.0f),
                        0.0f, x + Random.Range(20.0f, 30.0f));
                edge = spawnPosition.z;
                GameObject obj = gatePool.Activate(spawnPosition, Quaternion.identity);
                if (obj != null)
                {
                    obj.GetComponent<Gates>().SetData(gateData[Random.Range(0, gateData.Length)]);
                    if (Random.value>0.1f)
                        obj.GetComponent<Gates>().SetAbility
                            //(abilityData[Random.Range(0, abilityData.Length)]);
                            (abilityData[6]);
                    else
                        obj.GetComponent<Gates>().SetAbility
                            (abilityData[0]);
                }

                if (Random.value < 0.7f)
                {
                    if (Random.value > 0.5f)
                        SpawnWall();
                    else
                        SpawnDangerZone();
                }
            }
            yield return new WaitForSeconds(Random.Range(1.0f, 1.5f));
        }

    }

    void SpawnWall()
    {
        
                float x = ball.position.z > edge ? ball.position.z : edge;
                Vector3 spawnPosition = new Vector3(Random.Range(-8.0f, 8.0f),
                        0.0f, x + Random.Range(20.0f, 30.0f));
                GameObject obj = wallPool.Activate(spawnPosition, Quaternion.identity);
            if (obj != null)
            {
                obj.GetComponent<Walls>().SetData(wallData[Random.Range(0, wallData.Length)]);
            }
        
       
    }

    void SpawnDangerZone()
    {
        
            float x = ball.position.z > edge ? ball.position.z : edge;
            Vector3 spawnPosition = new Vector3(Random.Range(-8.0f, 8.0f),
                    0.2f, x + Random.Range(20.0f, 30.0f));
            dangerZonePool.Activate(spawnPosition, Quaternion.Euler(90.0f,0.0f,0.0f));
        
    }
}
