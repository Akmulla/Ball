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

    public static float cylinderRadius;
    float scale;
    float edge;

	void Start ()
	{
        cylinderRadius = gatePool.obj.GetComponentInChildren<CapsuleCollider>().radius;
		ball = BallMove.ball.transform;
        edge=30.0f;
		StartCoroutine (SpawnGate ());
	}

    IEnumerator SpawnGate()
    {
        //yield return new WaitForSeconds(1.0f);
        while (true)
        {
            if (edge - ball.position.z < 100.0f)
            {
                if (Random.value < 0.8f)
                    SpawnOneGate();
                else
                    SpawnCorridor();

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

    void SpawnOneGate()
    {
        float x = ball.position.z > edge ? ball.position.z : edge;
        GateDataClass currentGateData = gateData[Random.Range(0, gateData.Length)];
        Vector3 spawnPosition = new Vector3(Random.Range
            (-9.0f + currentGateData.size, 9.0f - currentGateData.size),
            0.0f, x + Random.Range(25.0f, 35.0f));
        edge = spawnPosition.z;
        GameObject obj = gatePool.Activate(spawnPosition, Quaternion.identity);
        if (obj != null)
        {
            obj.GetComponent<Gates>().SetData(gateData[Random.Range(0, gateData.Length)]);
            if (Random.value > 0.1f)
                obj.GetComponent<Gates>().SetAbility
                    (abilityData[Random.Range(0, abilityData.Length)]); //случайная абилка
                    //(abilityData[7]);
            else
                obj.GetComponent<Gates>().SetAbility
                    (abilityData[0]); //без абилок
        }

       
}
    void SpawnCorridor()
    {
        float x = ball.position.z > edge ? ball.position.z : edge;
        int p = Random.Range(2, 5);
        Vector3 spawnPosition = Vector3.zero;
        GateDataClass currentGateData = gateData[Random.Range(0, gateData.Length)];
        for (int i=0;i<p;i++)
        {
            if (i == 0)
                spawnPosition = new Vector3(Random.Range
                    (-9.0f+currentGateData.size, 9.0f- currentGateData.size),
                        0.0f, x + Random.Range(25.0f, 35.0f));
            else
                spawnPosition.z += cylinderRadius*3.0f;

            edge = spawnPosition.z;
            GameObject obj = gatePool.Activate(spawnPosition, Quaternion.identity);
            if (obj != null)
            {
                obj.GetComponent<Gates>().SetData(currentGateData);
                if ((i==0) && (Random.value > 0.1f))
                    obj.GetComponent<Gates>().SetAbility
                        (abilityData[Random.Range(0, abilityData.Length)]); //случайная абилка
                else
                    obj.GetComponent<Gates>().SetAbility
                        (abilityData[0]); //без абилок
            }
        }
    }

    void SpawnWall()
    {
        float x = ball.position.z > edge ? ball.position.z : edge;
        Vector3 spawnPosition = new Vector3(Random.Range(-8.0f, 8.0f),
                0.0f, x + Random.Range(10.0f, 20.0f));
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
                0.2f, x + Random.Range(10.0f, 20.0f));
        dangerZonePool.Activate(spawnPosition, Quaternion.Euler(90.0f,0.0f,0.0f));
       
    }
}
