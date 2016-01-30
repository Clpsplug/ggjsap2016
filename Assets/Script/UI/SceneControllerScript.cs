﻿using UnityEngine;
using System.Collections;

public class SceneControllerScript : MonoBehaviour {

	// 現在の表示中のUI
	private int current_scene = Define.UI_TITLE_MAIN;
//	private int current_scene = 4;

	// 各シーンのviewを登録
	public GameObject mainView;
	public GameObject titleView;
	public GameObject helpView;
	public GameObject gameOverView;
	public GameObject storyView;

	// Use this for initialization
	void Start () {
		showScene (current_scene);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/**
	 * シーン表示
	 * 
	 * @param	_index int
	 */
	public void showScene( int _index){
		
		titleView.SetActive (false);
		helpView.SetActive (false);
		storyView.SetActive (false);
		gameOverView.SetActive (false);

		switch (_index) {
		case Define.UI_TITLE_MAIN:
			mainView.SetActive (false);
			titleView.SetActive (true);
			break;
		case Define.UI_HELP_MAIN:
			helpView.SetActive (true);
			break;
		case Define.UI_STORY_MAIN:
			storyView.SetActive (true);
			break;
		case Define.UI_GAMEOVER_MAIN:
			gameOverView.SetActive (true);
			break;
		default:
			mainView.SetActive (true);
			break;
		}
	}
}