using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	public void PauseGame()
	{
		if (!MainController.isPaused)
		{
			MainController.Pause ();
		} else
		{
			MainController.Unpause ();
		}
	}
}
