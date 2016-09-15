using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallControl : MonoBehaviour
{
	Touch myTouch;
	bool moveRight;
	BallMove ballMove;
    [SerializeField]
    float screenSpeedCoeff;

    void Awake()
    {
        Input.gyro.enabled = true;
    }

    void Start()
	{
		ballMove = GetComponent<BallMove> ();
	}

	void Update () 
	{
        GyroControl();
    }


    void GyroControl()
    {
        Vector3 direction= new Vector3(0, 0, 1);
        direction.x = Input.acceleration.x;
        ballMove.movement = direction*screenSpeedCoeff;
    }

    void ScreenControl()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            myTouch = Input.GetTouch(0);
            //Vector3 touchPosition = Camera.main.ScreenToWorldPoint(myTouch.position);
            Vector3 touchPosition = new Vector3(myTouch.position.x, myTouch.position.y, transform.position.z);
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(touchPosition);

            Vector3 direction = newPosition - transform.position;
            direction.Normalize();
            direction *= screenSpeedCoeff;
            direction.z = 1;
        //
            direction.y = 0;
        //
            ballMove.movement = direction;
        }
}
	

}
