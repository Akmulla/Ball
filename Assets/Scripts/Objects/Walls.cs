using UnityEngine;
using System.Collections;

public class Walls : MonoBehaviour
{
    public WallDataClass wallData;
    Transform wallTransform;
    public ToPoolOnExit toPool;

    void Awake()
    {
        wallTransform = GetComponent<Transform>();
    }


    public void SetData(WallDataClass newWallData)
    {
        wallData = newWallData;
        wallTransform.localScale = new Vector3(wallData.size, 5.0f, 1.0f);
    }


    void OnCollisionEnter(Collision coll)
    {
        toPool.pool.Deactivate(gameObject);
        Score.SetScore -= wallData.score;
    }
}
