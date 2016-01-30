using UnityEngine;
using System.Collections;
using System;

public class RandomWall : MonoBehaviour {
    private int mWallsNumber;                                       //壁の親オブジェクト"Walls"の数
    private int mSeedValue = Environment.TickCount;                 //シード値
    private int[] mRandomArray;                                     //乱数の値を入れる配列
    private GameObject mWalls;                                      //壁の親オブジェクト"Walls"

    private bool mInitFlag = true;                                  //生成された"Walls"のカウント用

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (mInitFlag)
        {
            mWallsNumber = GameObject.Find("WallParent").transform.childCount;      //"Walls"の数を取得
            mRandomArray = new int[mWallsNumber];                                   //"Walls"の数だけ配列を確保

            System.Random rnd = new System.Random(mSeedValue++);                    //乱数
            for (int i = 0; i < mWallsNumber; i++)
            {
                mRandomArray[i] = rnd.Next(5);                                      //乱数を取得
            }

            for (int i = 0; i < mWallsNumber; i++)                                  //"Walls"の数だけ乱数を評価
            {
                mWalls = GameObject.Find("Walls" + i);
                switch (mRandomArray[i])
                {
                    case 0:
                        HideWall("Up");
                        HideWall("Left");
                        break;

                    case 1:
                        HideWall("Up");
                        HideWall("Right");
                        break;

                    case 2:
                        HideWall("Up");
                        HideWall("Under");
                        break;

                    case 3:
                        HideWall("Left");
                        HideWall("Right");
                        break;

                    case 4:
                        HideWall("Left");
                        HideWall("Under");
                        break;

                    case 5:
                        HideWall("Right");
                        HideWall("Under");
                        break;
                }
            }
            mInitFlag = false;
        }
        if (Input.GetKey(KeyCode.Return))                                                //デバッグ用マップ生成
        {
            System.Random rnd = new System.Random(mSeedValue++);
            for (int i = 0; i < mWallsNumber; i++)
            {
                mWalls = GameObject.Find("Walls" + i);
                HideWall("Reset");
                mRandomArray[i] = rnd.Next(5);
                mInitFlag = true;
            }
        }
    }

    void HideWall(string inWall)
    {
        switch (inWall)
        {
            case "Up":
                if (mWalls.transform.FindChild("Up"))
                {
                    mWalls.transform.FindChild("Up").GetComponent<BoxCollider>().enabled = false;
                    mWalls.transform.FindChild("Up").GetComponent<MeshRenderer>().enabled = false;
                }
                break;

            case "Left":
                if (mWalls.transform.FindChild("Left"))
                {
                    mWalls.transform.FindChild("Left").GetComponent<BoxCollider>().enabled = false;
                    mWalls.transform.FindChild("Left").GetComponent<MeshRenderer>().enabled = false;
                }
                break;

            case "Right":
                if (mWalls.transform.FindChild("Right"))
                {
                    mWalls.transform.FindChild("Right").GetComponent<BoxCollider>().enabled = false;
                    mWalls.transform.FindChild("Right").GetComponent<MeshRenderer>().enabled = false;
                }
                break;

            case "Under":
                if (mWalls.transform.FindChild("Under"))
                {
                    mWalls.transform.FindChild("Under").GetComponent<BoxCollider>().enabled = false;
                    mWalls.transform.FindChild("Under").GetComponent<MeshRenderer>().enabled = false;
                }
                break;

            case "Reset":
                if (mWalls.transform.FindChild("Up"))
                {
                    mWalls.transform.FindChild("Up").GetComponent<BoxCollider>().enabled = true;
                    mWalls.transform.FindChild("Up").GetComponent<MeshRenderer>().enabled = true;
                }
                else
                {
                    mWalls.transform.FindChild("MaxUp").GetComponent<BoxCollider>().enabled = true;
                    mWalls.transform.FindChild("MaxUp").GetComponent<MeshRenderer>().enabled = true;
                }

                if (mWalls.transform.FindChild("Left"))
                {
                    mWalls.transform.FindChild("Left").GetComponent<BoxCollider>().enabled = true;
                    mWalls.transform.FindChild("Left").GetComponent<MeshRenderer>().enabled = true;
                }
                else
                {
                    mWalls.transform.FindChild("MinLeft").GetComponent<BoxCollider>().enabled = true;
                    mWalls.transform.FindChild("MinLeft").GetComponent<MeshRenderer>().enabled = true;
                }

                if (mWalls.transform.FindChild("Right"))
                {
                    mWalls.transform.FindChild("Right").GetComponent<BoxCollider>().enabled = true;
                    mWalls.transform.FindChild("Right").GetComponent<MeshRenderer>().enabled = true;
                }
                else
                {
                    mWalls.transform.FindChild("MaxRight").GetComponent<BoxCollider>().enabled = true;
                    mWalls.transform.FindChild("MaxRight").GetComponent<MeshRenderer>().enabled = true;
                }

                if (mWalls.transform.FindChild("Under"))
                {
                    mWalls.transform.FindChild("Under").GetComponent<BoxCollider>().enabled = true;
                    mWalls.transform.FindChild("Under").GetComponent<MeshRenderer>().enabled = true;
                }
                else
                {
                    mWalls.transform.FindChild("MinUnder").GetComponent<BoxCollider>().enabled = true;
                    mWalls.transform.FindChild("MinUnder").GetComponent<MeshRenderer>().enabled = true;
                }
                break;
        }
    }
}
