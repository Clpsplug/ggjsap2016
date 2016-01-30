using UnityEngine;
using System.Collections;
using System;

public class CreateItem : MonoBehaviour {
    private const int ITEM_NUMBER = 5;                                  //アイテムの数

    private int mSeedValue = Environment.TickCount;                     //シード値
    private int[] mRandomArray = new int[ITEM_NUMBER];                  //乱数の値を入れる配列    果物・酒・塩・魚・刀
    [SerializeField]
    private GameObject[] mItemObjArray = new GameObject[ITEM_NUMBER];   //アイテムのオブジェクト配列
    private int mMapSize;                                               //マップサイズの取得
    private int mRoadNumber;                                            //通路(部屋)の数

	// Use this for initialization
	void Start () {
        mMapSize = GameObject.Find("MazeParent").GetComponent<CreateWall>().mMapSize - 1;
        mRoadNumber = mMapSize * mMapSize;
        System.Random rnd = new System.Random(mSeedValue++);
        for (int i = 0; i < ITEM_NUMBER; i++)
        {
            mRandomArray[i] = rnd.Next(mRoadNumber);
            Vector3 ababa = new Vector3((mRandomArray[i] % mMapSize - mMapSize / 2) * 7, 3, (mRandomArray[i] / mMapSize - mMapSize / 2) * 7);

            GameObject item = (GameObject)Instantiate(mItemObjArray[i], ababa, new Quaternion());
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
