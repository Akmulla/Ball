using UnityEngine;
using System.Collections;

public class OutsideRing : MonoBehaviour {
	public string poolName;
	Pool pool;
	Collider coll;

	// Use this for initialization
	void Start () 
	{
		pool = GameObject.Find (poolName).GetComponent<Pool> ();
		coll = GetComponent<Collider> ();
	}
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.name == "Ball")
		{
			pool.Deactivate (transform.parent.gameObject);
			//Destroy (gameObject);
		}
	}
}
