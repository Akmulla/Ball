using UnityEngine;
using System.Collections;

public class OutsideRing : MonoBehaviour {
	public string poolName;
	Pool pool;

	// Use this for initialization
	void Start () 
	{
		pool = GameObject.Find (poolName).GetComponent<Pool> ();
	}
	void OnCollisionEnter(Collision coll)
	{
		if (coll.gameObject.name == "Ball")
		{
			pool.Deactivate (gameObject);
			//Destroy (gameObject);
		}
	}
}
