using UnityEngine;
using System.Collections;

public class GenerateRoad : MonoBehaviour
{
	public Transform ball;
    public Pool blockPool;
	//public Pool brickPool;
    //public Pool wallPool;
	//float brickSize;
    float blockSize;
    //float wallSize;
	float edge;

	void Start ()
	{
		//brickPool = GetComponentInChildren<Pool> ();
		//GameObject road = brickPool.obj;
        GameObject block = blockPool.obj;
        //GameObject wall = wallPool.obj;
        blockSize =block.GetComponent<BoxCollider>().size.y * block.transform.localScale.y;
        //brickSize = road.GetComponent<BoxCollider> ().size.y * road.transform.localScale.y;
        //wallSize = wall.GetComponent<BoxCollider>().size.x * road.transform.localScale.x;
        //edge = brickSize/2;
        blockPool.Activate(new Vector3(0.0f, 0.0f, 0.0f), Quaternion.Euler(90.0f, 0.0f, 0.0f));
        edge = 0.0f;
	}

	void Update () 
	{
		if (ball.position.z > edge-80.0f)
		{
            //if (Random.value > 0.7f)
            //{
            //    GenerateParticle();
            //}
            //else
            {
                GenerateBlock();
            }
		}
	}
		
	/// <summary>
	/// Generate big block on the edge
	/// </summary>
	void GenerateBlock()
	{
		blockPool.Activate(new Vector3 (0.0f,0.0f,edge+blockSize/2.0f),Quaternion.Euler(90.0f,0.0f,0.0f));
		//pool.Activate(new Vector3 (ball.transform.position.x,0.0f,ball.transform.position.z),Quaternion.Euler(90.0f,0.0f,0.0f));
		edge += blockSize;
	}

    /// <summary>
    /// Generate line of the separate bricks and walls
    /// </summary>
    //void GenerateParticle()
    //{
       
    //    int brickCount = (int)(((int)Edges.rightWall - (int)Edges.leftWall) / brickSize);
    //    int hole = Random.Range(0, brickCount)+(int)Edges.leftEdge;
    //    GenerateWalls();
    //    for (int i=(int)Edges.leftWall;i<brickCount;i++)
    //    {
    //        if (i != hole)
    //        {
    //            brickPool.Activate(new Vector3(i, 0.0f, edge + brickSize/2),
    //            Quaternion.Euler(90.0f, 0.0f, 0.0f));
    //        }
    //    }
    //    edge += brickSize;
    //}

    //void GenerateWalls()
    //{
    //    wallPool.Activate(new Vector3(Edges.leftWall+wallSize/2, 0.0f, edge + brickSize / 2),Quaternion.identity);
    //    wallPool.Activate(new Vector3(Edges.rightWall- wallSize / 2, 0.0f, edge + brickSize / 2), Quaternion.identity);
    //}
}
