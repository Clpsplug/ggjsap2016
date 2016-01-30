using UnityEngine;
using System.Collections;

public class ImgHpGaugeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// HP
	public void setHp( int _now, int _max ){
		float _percent = _now / _max;
	}
}
