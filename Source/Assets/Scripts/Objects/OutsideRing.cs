using UnityEngine;
using System.Collections;

public class OutsideRing : MonoBehaviour 
{
	public string poolName;
	//Pool pool;
	//Collider coll;

	// Use this for initialization
	void Start () 
	{
		//pool = GameObject.Find (poolName).GetComponent<Pool> ();

	}
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.name == "Ball")
		{
            //GenerateRings.ringPool.Deactivate (transform.parent.gameObject);
            //GenerateRings.ringPool.Deactivate(transform.gameObject);
            //Destroy (gameObject);
        }
	}
}
