﻿using UnityEngine;
using System.Collections;

public class BtnRetryScript : MonoBehaviour {

	// メインユー
	public SceneControllerScript _scene;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// 
	public void retry(){
//		Debug.Log ("BtnRetryScript :: retry");
		_scene.showScene (0);
	}
}
