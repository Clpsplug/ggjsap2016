﻿using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public int move_flag = 1; //UIから引数をもらう予定
    public UICanvasScript UI;
    public SceneControllerScript scene;

    private int max_hp = 500;
    private int now_hp = 0; 

	// Use this for initialization
	void Start () {
        now_hp = max_hp;
        UI.setHp(now_hp, max_hp);
    }
	
	// Update is called once per frame
	void Update () {
        if (move_flag == 1)
        {
            speed = 10.0f;
            if (Input.GetKey("w"))
            {
                gameObject.GetComponent<Transform>().position += transform.forward * Time.deltaTime * speed;
                if (0 < now_hp)
                {
                    now_hp--;
                }
                else if (now_hp <= 0)
				{
					move_flag = 0;
                    // gameover
					scene.showScene(Define.UI_GAMEOVER_MAIN);
					UI.myEvent.AddListener (restart);
				}
                UI.setHp(now_hp, max_hp);

            }

            if (Input.GetKey("d"))
            {
                // Debug.Log("dKey");
                gameObject.GetComponent<Transform>().Rotate(0, 50.0f * Time.deltaTime, 0);
            }

            if (Input.GetKey("a"))
            {
                //Debug.Log("aKey");
                gameObject.GetComponent<Transform>().Rotate(0, -50.0f * Time.deltaTime, 0);
            }
        } else
        {
            speed = 0;
        }
    }

	/**
	 * 	リスタート処理
	 */
	public void restart(){
		move_flag = 1;
		now_hp = max_hp;
		UI.setHp(now_hp, max_hp);
		UI.myEvent.RemoveListener (restart);
	}
}
