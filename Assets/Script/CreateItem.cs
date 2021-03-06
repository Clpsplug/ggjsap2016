﻿using UnityEngine;
using System.Collections;
using System;

public class CreateItem : MonoBehaviour {
    private const int MAP_SIZE = 15;                                    //マップサイズ
    private const int ITEM_NUMBER = 5;                                  //アイテムの数

    private int mSeedValue = Environment.TickCount;                     //シード値
    private string[] mItemNameArray = new string[ITEM_NUMBER]
        {"Fruits", "Liquor", "Salt", "Fish", "Katana"};                 //アイテム名の配列
    private string[] mTagNameArray = new string[ITEM_NUMBER]
        {"izanami", "sukunahiko", "shiotsuti", "isotakeru", "takeminakata"}; //タグ名の配列
    private Color[] mHokoraColorArray = new Color[ITEM_NUMBER]
        {new Color(255, 176, 34),new Color(94, 255, 122),
            new Color(114, 255, 168),new Color(255, 129, 255),
                                        new Color(255, 242, 142)};       //色の配列
    [SerializeField]
    private int[] mRandomArray = new int[ITEM_NUMBER]
                                            {-1, -1, -1, -1, -1};       //乱数の値を入れる配列          果物・酒・塩・魚・刀
    [SerializeField]
    private int[] mFakeArray = new int[ITEM_NUMBER]
                                            {-1, -1, -1, -1, -1};       //偽物の乱数の値を入れる配列    果物・酒・塩・魚・刀
    [SerializeField]
    private int[] mHokoraArray = new int[ITEM_NUMBER]
                                            {-1, -1, -1, -1, -1};       //祠の乱数の値を入れる配列   　 果物・酒・塩・魚・刀
    [SerializeField]
    private int mKamidanaValue;                                         //神棚の乱数の値を入れる
    [SerializeField]
    private GameObject[] mItemObjArray = new GameObject[ITEM_NUMBER];   //アイテムのオブジェクト配列
    [SerializeField]
    private GameObject mHokoraObj;                                      //祠
    [SerializeField]
    private GameObject mKamidanaObj;                                    //神棚
    private int mRoadNumber = MAP_SIZE * MAP_SIZE;                      //通路(部屋)の数

    // Use this for initialization
    void Start()
    {
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
            Vector3 itemPosition = new Vector3((mRandomArray[i] % MAP_SIZE - MAP_SIZE / 2) * 7, 1.5f, (mRandomArray[i] / MAP_SIZE - MAP_SIZE / 2) * 7);
            GameObject item = (GameObject)Instantiate(mItemObjArray[i], itemPosition, new Quaternion());
            item.name = mItemNameArray[i];
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
                        mFakeArray[j] = rnd.Next(mRoadNumber);        //配列のj番目を再抽選
                        fakeMismatch = false;                         //不一致フラグをfalseに設定(乱数に重複がある)
                    }
                }
            }

            for (int i = 0; i < ITEM_NUMBER - 1; i++)                 //自身の配列との比較
            {
                for (int j = i + 1; j < ITEM_NUMBER; j++)
                {
                    if (mFakeArray[i] == mFakeArray[j] ||           //乱数に重複があるか
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
            Vector3 fakeItemPosition = new Vector3((mFakeArray[i] % MAP_SIZE - MAP_SIZE / 2) * 7, 1.5f, (mFakeArray[i] / MAP_SIZE - MAP_SIZE / 2) * 7);
            GameObject item = (GameObject)Instantiate(mItemObjArray[i], fakeItemPosition, new Quaternion());
            item.name = "Fake_" + mItemNameArray[i];
        }

        /***********************祠を生成*************************/

        for (int i = 0; i < ITEM_NUMBER; i++)                         //重複を無視して乱数を設定
        {
            mHokoraArray[i] = rnd.Next(mRoadNumber);
        }
        bool hokoraMismatch = false;                                  //不一致フラグをfalseに設定(乱数に重複した値があると仮定)
        while (!hokoraMismatch)                                       //重複した値があればループ
        {
            hokoraMismatch = true;                                    //不一致フラグをtrueに設定(乱数に重複が無いと仮定)
                                                                      //最後まで重複が無ければこのままループを抜ける
            for (int i = 0; i < ITEM_NUMBER; i++)                     //各アイテム配列との比較
            {
                for (int j = 0; j < ITEM_NUMBER; j++)
                {
                    if (mRandomArray[i] == mHokoraArray[j] ||
                        mFakeArray[i] == mHokoraArray[j]
                        )
                    {
                        mHokoraArray[j] = rnd.Next(mRoadNumber);      //配列のj番目を再抽選
                        hokoraMismatch = false;                       //不一致フラグをfalseに設定(乱数に重複がある)
                    }
                }
            }

            for (int i = 0; i < ITEM_NUMBER - 1; i++)                 //自身の配列との比較
            {
                for (int j = i + 1; j < ITEM_NUMBER; j++)
                {
                    if (mHokoraArray[i] == mHokoraArray[j] ||             //乱数に重複があるか
                        mHokoraArray[i] == mRoadNumber / 2 ||
                        mHokoraArray[j] == mRoadNumber / 2)             //生成位置がプレイヤーの初期位置ならば
                    {
                        mHokoraArray[i] = rnd.Next(mRoadNumber);        //配列のi番目を再抽選
                        mHokoraArray[j] = rnd.Next(mRoadNumber);        //配列のj番目を再抽選
                        hokoraMismatch = false;                       //不一致フラグをfalseに設定(乱数に重複がある)
                    }
                }
            }
        }
        for (int i = 0; i < ITEM_NUMBER; i++)
        {
            Vector3 hokoraPosition = new Vector3((mHokoraArray[i] % MAP_SIZE - MAP_SIZE / 2) * 7, 0.5f, (mHokoraArray[i] / MAP_SIZE - MAP_SIZE / 2) * 7);
            GameObject hokora = (GameObject)Instantiate(mHokoraObj, hokoraPosition, new Quaternion());
            hokora.name = mTagNameArray[i] + "Hokora";
            hokora.tag = mTagNameArray[i];
            hokora.GetComponent<Light>().color = mHokoraColorArray[i];
        }

        /***********************神棚を生成*************************/

        for (int i = 0; i < ITEM_NUMBER; i++)                         //重複を無視して乱数を設定
        {
            mKamidanaValue = rnd.Next(mRoadNumber);
        }
        bool kamidanaMismatch = false;                                  //不一致フラグをfalseに設定(乱数に重複した値があると仮定)
        while (!kamidanaMismatch)                                       //重複した値があればループ
        {
            kamidanaMismatch = true;                                    //不一致フラグをtrueに設定(乱数に重複が無いと仮定)
                                                                        //最後まで重複が無ければこのままループを抜ける
            for (int i = 0; i < ITEM_NUMBER; i++)                     //各アイテム配列との比較
            {
                if (mRandomArray[i] == mKamidanaValue ||
                    mFakeArray[i]   == mKamidanaValue ||
                    mHokoraArray[i] == mKamidanaValue)
                {
                    mKamidanaValue = rnd.Next(mRoadNumber);            //配列のj番目を再抽選
                    kamidanaMismatch = false;                       //不一致フラグをfalseに設定(乱数に重複がある)
                }
            }
        }
        Vector3 kamidanaPosition = new Vector3((mKamidanaValue % MAP_SIZE - MAP_SIZE / 2) * 7, 0.5f, (mKamidanaValue / MAP_SIZE - MAP_SIZE / 2) * 7);
        GameObject kamidana = (GameObject)Instantiate(mKamidanaObj, kamidanaPosition, new Quaternion());
        kamidana.name = "Kamidana";
    }

    // Update is called once per frame
    void Update () {

    }
}
