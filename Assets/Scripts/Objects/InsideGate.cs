using UnityEngine;
using System.Collections;

public class InsideGate : MonoBehaviour
{
    //public GateDataClass gateData;
    public Gates gate;

	void Start()
	{
		
	}
	
	void OnTriggerExit(Collider other) 
	{
		gate.GoThroughRing ();
	}

	//void GoThroughRing()
	//{
 //       Score.SetScore += gateData.score;
	//}
}
