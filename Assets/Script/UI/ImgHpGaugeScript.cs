using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImgHpGaugeScript : MonoBehaviour {

	public Image gauge;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// HP
	public void setHp( int _now, int _max ){
		float _percent = (float)(_now) / _max;
		gauge.fillAmount = _percent;
	}
}
