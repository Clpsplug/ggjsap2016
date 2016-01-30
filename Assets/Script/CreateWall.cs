using UnityEngine;
using System.Collections;
using System;

public class CreateWall : MonoBehaviour {
    private const int SIDE_LENGTH = 6;                  //マップの一辺の柱の本数(偶数のみです、すみません)
    private const int WALL_LENGHT = SIDE_LENGTH - 1;     //マップの一辺の壁の数

    private GameObject mPillarObj;                                  //柱
    private GameObject mWidthWallObj;                               //横壁
    private GameObject mHeightWallObj;                              //縦壁
    private GameObject mWalls;                                      //壁の親オブジェクト

    private int mUpParentIndex = 0;                                 //上壁の指標
    private int mLeftParentIndex = 0;                               //左壁の指標
    private int mRightParentIndex = 0;                              //右壁の指標
    private int mUnderParentIndex = 0;                              //左壁の指標

    private int mWallsNum = 0;                                      //壁の親オブジェクトの数
    private GameObject[] mWallsParentArray =
                            new GameObject[SIDE_LENGTH * SIDE_LENGTH / 2 - (SIDE_LENGTH / 2)];
                                                                    //壁の親オブジェクトを格納する配列

    // Use this for initialization
    void Start () {
        mPillarObj = (GameObject)Resources.Load("Pillar");
        mWidthWallObj = (GameObject)Resources.Load("WidthWall");
        mHeightWallObj = (GameObject)Resources.Load("HeightWall");
        mWalls = (GameObject)Resources.Load("Walls");

        for (int i = 0; i < SIDE_LENGTH * SIDE_LENGTH / 2 - (SIDE_LENGTH / 2); i++)               // 壁の親オブジェクトの生成
        {
            GameObject walls = (GameObject)Instantiate(mWalls, Vector3.zero, new Quaternion());
            walls.name = "Walls" + mWallsNum;
            walls.transform.parent = GameObject.Find("WallParent").transform;
            mWallsParentArray[mWallsNum] = walls;
            mWallsNum++;
        }
        mWallsNum = 0;

        for (int i = 1; i <= SIDE_LENGTH; i++)                      //柱の生成
        {
            for (int j = 1; j <= SIDE_LENGTH; j++)
            {
                GameObject pillar = (GameObject)Instantiate(mPillarObj, new Vector3((j - 1) * 5 + 2.5f, 1, (i - 1) * 5 + 2.5f), new Quaternion(0, 0, 0, 0));
                pillar.name = "Pillar" + i + "," + j;
                pillar.transform.parent = GameObject.Find("PillarParent").transform;
            }
        }
        for (int i = 1; i <= SIDE_LENGTH; i++)                      //壁の生成
        {
            for(int j = 1; j <= WALL_LENGHT; j++)
            {
                GameObject widthWall = (GameObject)Instantiate(mWidthWallObj, new Vector3(j * 5, 1, (i - 1) * 5 + 2.5f), new Quaternion());         //横壁の生成
                if (i % 2 == 1)                         //奇数ならUnder,偶数ならUp
                {
                    widthWall.name = "Under";
                    widthWall.transform.parent = mWallsParentArray[mUnderParentIndex].transform;
                    mUnderParentIndex++;

                    if (i == 1)
                    {
                        widthWall.name = "MinUnder";
                    }
                }
                else
                {
                    widthWall.name = "Up";
                    widthWall.transform.parent = mWallsParentArray[mUpParentIndex].transform;
                    mUpParentIndex++;

                    if (i == SIDE_LENGTH)
                    {
                        widthWall.name = "MaxUp";
                    }
                }

                GameObject heightWall = (GameObject)Instantiate(mHeightWallObj, new Vector3((i - 1) * 5 + 2.5f, 1, j * 5 ), new Quaternion());      //縦壁の生成
                if (i % 2 == 1)                         //奇数ならLeft,偶数ならRight
                {
                    heightWall.name = "Left";
                    heightWall.transform.parent = mWallsParentArray[mLeftParentIndex].transform;
                    mLeftParentIndex++;

                    if (i == 1)
                    {
                        widthWall.name = "MinLeft";
                    }
                }
                else
                {
                    heightWall.name = "Right";
                    heightWall.transform.parent = mWallsParentArray[mRightParentIndex].transform;
                    mRightParentIndex++;

                    if (i == SIDE_LENGTH)
                    {
                        widthWall.name = "MaxRight";
                    }
                }

                
                
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
