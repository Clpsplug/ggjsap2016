using UnityEngine;
using System.Collections;

public class AmaterasuPower : MonoBehaviour {
    private const int ITEM_NUMBER = 5;                                  //アイテムの数

    private ItemFlags mItemFlags;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            for (int i = 0; i < ITEM_NUMBER; i++)
            {
                //mItemFlags
            }
        }
	}
}
