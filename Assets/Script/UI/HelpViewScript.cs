using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HelpViewScript : MonoBehaviour {

	public Text textPositiveKey;
	public Text textLeftKey;
	public Text textTopKey;
	public Text textRightKey;

	// Use this for initialization
	void Start () {
		// キーのセッティング
		textPositiveKey.text = Define.POSITIVE_KEY_STR;
		textLeftKey.text = Define.LEFT_KEY_STR;
		textTopKey.text = Define.FORWORD_KEY_STR;
		textRightKey.text = Define.RIGHT_KEY_STR;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
