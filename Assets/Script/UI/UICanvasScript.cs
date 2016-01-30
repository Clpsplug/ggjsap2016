using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UICanvasScript : MonoBehaviour {

	// itemlist
	private int[] itemArray = new int[]{ 0, 0, 0, 0, 0};

	// itemlist
	public GameObject[] spriteOffArray = new GameObject[5];
	public GameObject[] spriteOnArray = new GameObject[5];

	private List<int> items = new List<int>();

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
}
