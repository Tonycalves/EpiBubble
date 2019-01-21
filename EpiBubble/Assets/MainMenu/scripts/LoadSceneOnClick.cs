using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneOnClick : MonoBehaviour {

	public void LoadByIndex(int sceneIndex) {
		//MakeButtonSound();
		SceneManager.LoadScene (sceneIndex);
	}

}
