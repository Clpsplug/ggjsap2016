using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HelpButtonScript : MonoBehaviour {

	// メインユー
	public SceneControllerScript _scene;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {

	}

	// Update is called once per frame
	public void start () {
//		Debug.Log ("clicked");
		_scene.showScene (0);
	}
}
