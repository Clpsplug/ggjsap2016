using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverViewScript : MonoBehaviour {
	
	public Text textPositiveKey;

	// Use this for initialization
	void Start () {
		// キーのセッティング
		textPositiveKey.text = Define.POSITIVE_KEY_STR;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
