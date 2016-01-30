using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UICanvasScript : MonoBehaviour {

	// itemlist
	// 0:未所持
	// 1:供物所持
	// 2:札所持
	// 3:札使用
	private int[] itemArray = new int[]{ 0, 0, 0, 0, 0};

	// itemlist
	public GameObject[] spriteOffArray = new GameObject[5];
	public GameObject[] spriteOnArray = new GameObject[5];

	private List<int> items = new List<int>();

	// HP
	public ImgHpGaugeScript gauge;
	// お供えグラフィック
	public BtnDedicateScript dedicateInfo;

	// Use this for initialization
	void Start () {
		items.AddRange(itemArray);

		showItems();
	}

	// Update is called once per frame
	void Update () {

	}

	// 
	public void getItem( int _index){
		itemArray [_index] = 1;
		showItems ();
	}

	// 
	public void lostItem( int _index){
		itemArray [_index] = 0;
		showItems ();
	}

	// 
	private void showItems(){
		for (int i = 0; i < items.Count; i++) {
			spriteOnArray [i].SetActive (false);
			spriteOffArray [i].SetActive (false);
			if (0 < items [i]) {
				spriteOnArray [i].SetActive (true);
			} else {
				spriteOffArray [i].SetActive (true);
			}
		}
	}

	// お供え表示
	public void showDedicate( bool _bool){
		if(_bool){
			dedicateInfo.show ();
		} else {
			dedicateInfo.hide ();
		}
	}

	// HPセット
	public void setHp( int _now, int _max){
		gauge.setHp (_now, _max);
	}
}
