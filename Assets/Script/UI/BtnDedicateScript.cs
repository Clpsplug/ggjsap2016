using UnityEngine;
using System.Collections;

public class BtnDedicateScript : MonoBehaviour {

	public GameObject _self;

	// Use this for initialization
	void Start () {
		// 初め消しておく
		hide();
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
