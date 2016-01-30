using UnityEngine;
using System.Collections;
using System;

public class CreateWall : MonoBehaviour {
    private const int SIDE_LENGTH = 16;                  //マップの一辺の柱の本数(偶数のみです、すみません)
    private const int WALL_LENGTH = SIDE_LENGTH - 1;     //マップの一辺の壁の数

    private const float POSITION_Y = 4.0f;               //迷路生成時のY座標
    private const float WALL_INTERVAL = 7.0f;            //柱同士・壁同士の間隔
    private const float WALL_WIDTH = 6.0f;               //壁の長さ

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
                GameObject pillar = (GameObject)Instantiate(mPillarObj, new Vector3((j - 1) * WALL_INTERVAL + 3, POSITION_Y, (i - 1) * WALL_INTERVAL + 3), new Quaternion());
                pillar.name = "Pillar" + i + "," + j;
                pillar.transform.parent = GameObject.Find("PillarParent").transform;
            }
        }
        for (int i = 1; i <= SIDE_LENGTH; i++)                      //壁の生成
        {
            for(int j = 1; j <= WALL_LENGTH; j++)
            {
                GameObject widthWall = (GameObject)Instantiate(mWidthWallObj, new Vector3(j * WALL_INTERVAL -0.5f, POSITION_Y, (i - 1) * WALL_INTERVAL + 3), new Quaternion());         //横壁の生成
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

                GameObject heightWall = (GameObject)Instantiate(mHeightWallObj, new Vector3((i - 1) * WALL_INTERVAL + 3, POSITION_Y, j * WALL_INTERVAL - 0.5f), new Quaternion());      //縦壁の生成
                if (i % 2 == 1)                         //奇数ならLeft,偶数ならRight
                {
                    heightWall.name = "Left";
                    heightWall.transform.parent = mWallsParentArray[mLeftParentIndex].transform;
                    mLeftParentIndex++;

                    if (i == 1)
                    {
                        heightWall.name = "MinLeft";
                    }
                }
                else
                {
                    heightWall.name = "Right";
                    heightWall.transform.parent = mWallsParentArray[mRightParentIndex].transform;
                    mRightParentIndex++;

                    if (i == SIDE_LENGTH)
                    {
                        heightWall.name = "MaxRight";
                    }
                }
            }
        }
        Vector3 changePosition = new Vector3(-(SIDE_LENGTH * (WALL_WIDTH + 1) - 1) / 2, 0, -(SIDE_LENGTH * (WALL_WIDTH + 1) - 1) / 2);
        transform.position = changePosition;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
