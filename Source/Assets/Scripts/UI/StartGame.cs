using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	public void Begin()
	{
		//SceneManager.LoadScene ("Game");
		MainController.SwitchScene("Game");
	}
}
