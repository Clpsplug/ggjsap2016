using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BtnNextScript : MonoBehaviour {

	// テキストエリア
	public Text textfield;

	// Use this for initialization
	void Start () {
		textfield.text = Define.POSITIVE_KEY_STR;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// 次へ
	public void pressBtn(){
		Debug.Log ("BtnNextScript :: pressBtn");
	}
}
