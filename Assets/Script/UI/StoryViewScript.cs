using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StoryViewScript : MonoBehaviour {

	// ストーリ用テキストエリア
	public Text textfield;

	// 次へボタン
	public BtnNextScript btn_next;

	// テキスト
	[Multiline(3)]
	public string[] storyArray = new string[5];

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
