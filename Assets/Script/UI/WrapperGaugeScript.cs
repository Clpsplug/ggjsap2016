using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WrapperGaugeScript : MonoBehaviour {

	// 枠
	public GameObject frame;
	public GameObject frame_danger;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/**
	 * デンジャー状態？ 
	 * 
	 * @param	_index	int
	 * @param	_state	int
	 */
	public void checkDanger( int _now, int _max ){
		float _percent = (float)(_now) / _max * 100;
		if (_percent < Define.DANGER_HP_THREAD) {
			frame.SetActive (false);
			frame_danger.SetActive (true);
		} else {
			frame.SetActive (true);
			frame_danger.SetActive (false);
		}
	}
}
