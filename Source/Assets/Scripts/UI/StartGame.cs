using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	public void Begin()
	{
		MainController.SwitchScene("Game");
		//MainController.GetAsync().allowSceneActivation=true;
	}
}
