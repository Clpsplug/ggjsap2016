using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class HelpViewScript : MonoBehaviour {

	// テキスト
	public Text textPositiveKey;
	public Text textLeftKey;
	public Text textTopKey;
	public Text textRightKey;

	// view
	public GameObject parts;
	public CanvasGroup canvasGroup;

	// コールバック用変数
	public UnityEvent myEvent;

	// 面倒なのでコールバックするか裏具ココにおいておく
	private bool isCallBack = false;

	void Awake()
	{
		canvasGroup = parts.GetComponent<CanvasGroup>();
		// コールバック用変数生成
		myEvent = new UnityEvent();
	}

	// Use this for initialization
	void Start () {
		// キーのセッティング
		textPositiveKey.text = Define.POSITIVE_KEY_STR;
		textLeftKey.text = Define.LEFT_KEY_STR;
		textTopKey.text = Define.FORWORD_KEY_STR;
		textRightKey.text = Define.RIGHT_KEY_STR;

		fadeOut (0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void fadeIn( float _fadeTime ) {
//		Debug.Log ("fadeIn");
		StartCoroutine("FadeInF",_fadeTime);
	}
	public void fadeOut( float _fadeTime, bool _isCallback = false ) {
//		Debug.Log ("fadeOut");
		isCallBack = _isCallback;
		StartCoroutine("FadeOutF",_fadeTime);
	}

	IEnumerator FadeInF(float _fadeTime)
	{
		float time = _fadeTime;
		while(canvasGroup.alpha < 1)
		{
			canvasGroup.alpha += Time.deltaTime / time;
			yield return null;
		}
	}
	IEnumerator FadeOutF(float _fadeTime)
	{
		float time = _fadeTime;
		while(canvasGroup.alpha > 0)
		{
			canvasGroup.alpha -= Time.deltaTime / time;
			yield return null;
		}
		if(isCallBack) onComplete ();
	}

	/**
	 * リスタート
	 */
	public void onComplete(){
		myEvent.Invoke ();
	}
}
