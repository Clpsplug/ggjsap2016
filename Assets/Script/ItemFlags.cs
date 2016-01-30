﻿using UnityEngine;
using System.Collections;

public class ItemFlags : MonoBehaviour {

    public static int[] Items = new int[5];
    // 1果物
    // 2お酒
    // 3塩
    // 4魚
    // 5刀

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter (Collision col)
    {
        Debug.Log(col.gameObject.tag);
        switch (col.gameObject.tag.ToString())
        {
            case "orange":
                //果物
                Items[0] = 1;
                break;

            case "osake":
                //お酒
                Items[1] = 1;
                break;

            case "salt":
                //塩
                Items[2] = 1;
                break;

            case "fish":
                //魚
                Items[3] = 1;
                break;

            case "katana":
                //刀
                Items[4] = 1;
                break;
        }
    }
}