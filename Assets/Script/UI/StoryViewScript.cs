using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StoryViewScript : MonoBehaviour {
	// メインユー
	public SceneControllerScript _scene;

	// ストーリ用テキストエリア
	public Text textfield;

	// 次へボタン
	public BtnNextScript btn_next;
	public Button btn_obj;

	// 現在のカウンタ
	private int _count = 0;

	// テキスト
	[Multiline(3)]
	public string[] storyArray = new string[5];

	// Use this for initialization
	void Start () {
		_count = 0;
		textfield.text = storyArray [_count];
		btn_obj.onClick.AddListener(nextText);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(Define.POSITIVE_KEY_STR.ToLower()))
		{
			nextText ();
		}
	}

	private void nextText(){
//		Debug.Log ("nextText" + _count);
		if (_count < storyArray.Length - 1) {
			_count++;
			textfield.text = storyArray [_count];
		} else {
			_scene.showScene (Define.UI_HELP_MAIN);
		}
	}
}
