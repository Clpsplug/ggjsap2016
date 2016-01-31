using UnityEngine;
using System.Collections;
using System;

public class CreateItem : MonoBehaviour {
    private const int ITEM_NUMBER = 5;                                  //アイテムの数

    private int mSeedValue = Environment.TickCount;                     //シード値
    [SerializeField]
    private int[] mRandomArray = new int[ITEM_NUMBER]
                                            {-1, -1, -1, -1, -1};       //乱数の値を入れる配列          果物・酒・塩・魚・刀
    [SerializeField]
    private int[] mFakeArray = new int[ITEM_NUMBER]
                                            {-1, -1, -1, -1, -1};       //偽物の乱数の値を入れる配列    果物・酒・塩・魚・刀
    [SerializeField]
    private GameObject[] mItemObjArray = new GameObject[ITEM_NUMBER];   //アイテムのオブジェクト配列
    private int mMapSize;                                               //マップサイズの取得
    private int mRoadNumber;                                            //通路(部屋)の数

	// Use this for initialization
	void Start () {
        mMapSize = GameObject.Find("MazeParent").GetComponent<CreateWall>().mMapSize - 1;
        mRoadNumber = mMapSize * mMapSize;
        System.Random rnd = new System.Random(mSeedValue++);

                                            /***********************本物の供物を生成*************************/

        for (int i = 0; i < ITEM_NUMBER; i++)                       //重複を無視して乱数を設定
        {
            mRandomArray[i] = rnd.Next(mRoadNumber);
        }
        bool mismatch = false;                                      //不一致フラグをfalseに設定(乱数に重複した値があると仮定)
        while (!mismatch)                                           //重複した値があればループ
        {
            mismatch = true;                                        //不一致フラグをtrueに設定(乱数に重複が無いと仮定)
                                                                    //最後まで重複が無ければこのままループを抜ける
            for (int i = 0; i < ITEM_NUMBER - 1; i++)               //自身の配列との比較
            {
                for (int j = i + 1; j < ITEM_NUMBER; j++)
                {
                    if (mRandomArray[i] == mRandomArray[j] ||       //乱数に重複があるか
                        mRandomArray[i] == mRoadNumber / 2 ||
                        mRandomArray[j] == mRoadNumber / 2)         //生成位置がプレイヤーの初期位置ならば
                    {
                        mRandomArray[i] = rnd.Next(mRoadNumber);    //配列のi番目を再抽選
                        mRandomArray[j] = rnd.Next(mRoadNumber);    //配列のj番目を再抽選
                        mismatch = false;                           //不一致フラグをfalseに設定(乱数に重複がある)
                    }
                }
            }
        }
        for (int i = 0; i < ITEM_NUMBER; i++)
        {
            Vector3 itemPosition = new Vector3((mRandomArray[i] % mMapSize - mMapSize / 2) * 7, 2, (mRandomArray[i] / mMapSize - mMapSize / 2) * 7);
            GameObject item = (GameObject)Instantiate(mItemObjArray[i], itemPosition, new Quaternion());
        }

                                              /***********************偽物の供物を生成*************************/

        for (int i = 0; i < ITEM_NUMBER; i++)                         //重複を無視して乱数を設定
        {
            mFakeArray[i] = rnd.Next(mRoadNumber);
        }
        bool fakeMismatch = false;                                    //不一致フラグをfalseに設定(乱数に重複した値があると仮定)
        while (!fakeMismatch)                                         //重複した値があればループ
        {
            fakeMismatch = true;                                      //不一致フラグをtrueに設定(乱数に重複が無いと仮定)
                                                                      //最後まで重複が無ければこのままループを抜ける
            for (int i = 0; i < ITEM_NUMBER; i++)                     //本物の配列との比較
            {
                for (int j = 0; j < ITEM_NUMBER; j++)
                {
                    if (mRandomArray[i] == mFakeArray[j])
                    {
                        mFakeArray[j] = rnd.Next(mRoadNumber);        //配列のi番目を再抽選
                        fakeMismatch = false;                         //不一致フラグをfalseに設定(乱数に重複がある)
                    }
                }
            }

            for (int i = 0; i < ITEM_NUMBER - 1; i++)                 //自身の配列との比較
            {
                for (int j = i + 1; j < ITEM_NUMBER; j++)
                {
                    if (mFakeArray[i] == mFakeArray[j]   ||           //乱数に重複があるか
                        mFakeArray[i] == mRoadNumber / 2 ||
                        mFakeArray[j] == mRoadNumber / 2)             //生成位置がプレイヤーの初期位置ならば
                    {
                        mFakeArray[i] = rnd.Next(mRoadNumber);        //配列のi番目を再抽選
                        mFakeArray[j] = rnd.Next(mRoadNumber);        //配列のj番目を再抽選
                        fakeMismatch = false;                         //不一致フラグをfalseに設定(乱数に重複がある)
                    }
                }
            }
        }
        for (int i = 0; i < ITEM_NUMBER; i++)
        {
            Vector3 fakeItemPosition = new Vector3((mFakeArray[i] % mMapSize - mMapSize / 2) * 7, 2, (mFakeArray[i] / mMapSize - mMapSize / 2) * 7);
            GameObject item = (GameObject)Instantiate(mItemObjArray[i], fakeItemPosition, new Quaternion());
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
