using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
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
	public GameObject[] spriteHudaArray = new GameObject[5];
	public GameObject[] spriteEndArray = new GameObject[5];

	private List<int> items = new List<int>();

	// HPゲージ
	public ImgHpGaugeScript gauge;
	// HP枠
	public WrapperGaugeScript frame;
	// お供えグラフィック
	public BtnDedicateScript dedicateInfo;

	// コールバック用変数
	public UnityEvent myEvent;

	// Use this for initialization
	void Start () {
		// コールバック用変数生成
		myEvent = new UnityEvent();

		items.AddRange(itemArray);

		// お供え消す
		showDedicate (false);

		// HPセット
		setHp(100,100);

		showItems();
	}

	// Update is called once per frame
	void Update () {

	}

	// 
	private void showItems(){
		for (int i = 0; i < itemArray.Length; i++) {
			spriteOnArray [i].SetActive (false);
			spriteOffArray [i].SetActive (false);
			spriteHudaArray [i].SetActive (false);
			spriteEndArray [i].SetActive (false);

			Debug.Log ("showItems :: "+itemArray[i]);
			// アイテムの状態で表示状態を変更
			switch(itemArray [i]){
			case 1:// 1:供物所持
					spriteOnArray [i].SetActive (true);
					break;
			case 2:// 2:札所持
					spriteHudaArray [i].SetActive (true);
					break;
			case 3:// 3:札使用
					spriteEndArray [i].SetActive (true);
					break;
			default:// 0:未所持
					spriteOffArray [i].SetActive (true);
					break;
			}
		}
	}

	/**
	 * アイテムの表示状態
	 * 
	 * @param	_index	int
	 * @param	_state	int
	 */
	public void updateItem( int _index, int _state ){
		itemArray [_index] = _state;
		showItems ();
	}

	/**
	 * お供え表示
	 * 
	 * @param	_bool	bool
	 */
	public void showDedicate( bool _bool){
		if(_bool){
			dedicateInfo.show ();
		} else {
			dedicateInfo.hide ();
		}
	}

	/**
	 * HPセット
	 * 
	 * @param	_now	int
	 * @param	_max	int
	 */
	public void setHp( int _now, int _max){
		gauge.setHp (_now, _max);
		frame.checkDanger(_now, _max);
	}

	/**
	 * リスタート
	 */
	public void restart(){
		myEvent.Invoke ();
	}
}
