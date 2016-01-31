using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HelpButtonScript : MonoBehaviour {

	// メインユー
	public SceneControllerScript _scene;
	// メインユー
	public GameObject _help;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	// Update is called once per frame
	public void start () {
//		Debug.Log ("clicked");
//		_scene.showScene (0);
		HelpViewScript _view = _help.GetComponent<HelpViewScript>();
		_view.myEvent.AddListener(gamestart);
		_view.fadeOut (0.5f, true);
//		Debug.Log ("start");
	}

	public void gamestart(){
		_scene.showScene (Define.UI_SCENE_MAIN);
	}
}
