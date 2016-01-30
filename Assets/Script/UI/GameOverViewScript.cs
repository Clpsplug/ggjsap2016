using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverViewScript : MonoBehaviour {
	// メインユー
	public SceneControllerScript _scene;
	
	public Text textPositiveKey;

	public Button btn_obj;

	// Use this for initialization
	void Start () {
		// キーのセッティング
		textPositiveKey.text = Define.POSITIVE_KEY_STR;

		btn_obj.onClick.AddListener(restart);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(Define.POSITIVE_KEY_STR.ToLower()))
		{
			restart ();
		}
	
	}

	public void restart(){
		_scene.showScene (0);
	}
}
