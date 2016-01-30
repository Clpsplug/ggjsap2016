using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BtnDedicateScript : MonoBehaviour {

	public GameObject _self;

	public Text textKey;

	// Use this for initialization
	void Start () {
		// キーのセッティング
		textKey.text = Define.POSITIVE_KEY_STR;
	}
	
	// Update is called once per frame
	void Update () {
	}

	// 
	public void dedicate(){
		Debug.Log ("BtnDedicateScript :: dedicate");
	}

	// 
	public void show(){
		_self.SetActive (true);
	}

	// 
	public void hide(){
		_self.SetActive (false);
	}


}
