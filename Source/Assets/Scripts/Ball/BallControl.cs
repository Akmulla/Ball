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
            //Debug.Log (touchPosition);
            //Debug.Log(myTouch.position);
            //if (!EventSystem.current.IsPointerOverGameObject(myTouch.fingerId))
            /*{
				//if (touchPosition.z > transform.position.z)
				if (myTouch.position.x > Camera.main.pixelWidth/2.0f)
				{
					moveRight = true;
				}
				else
				{
					moveRight = false;
				}
				//ballMove.MakeStep (moveRight);
			}*/

    }


    void GyroControl()
    {
        //Debug.Log(Input.gyro.rotationRate);
        //Debug.Log(Input.gyro.rotationRateUnbiased);

        //Debug.Log(Input.acceleration.x);
        //Debug.Log(Input.acceleration.y);
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
