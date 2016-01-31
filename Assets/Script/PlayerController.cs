using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float rotate_speed;
    public int move_flag = 1; //UIから引数をもらう予定
    public UICanvasScript UI;
    public SceneControllerScript scene;

    private int max_hp = 5000; //要調整
    private int now_hp = 0;

    // Use this for initialization
    void Start() {
        now_hp = max_hp;
        UI.setHp(now_hp, max_hp);
    }

    // Update is called once per frame
    void Update() {
        if (move_flag == 1)
        {
            speed = 10.0f;
            rotate_speed = 1.0f;
            if (Input.GetKey("w"))
            {
                forward();
                if (0 < now_hp)
                {
                    now_hp--;
                }
                else if (now_hp <= 0)
                {
                    move_flag = 0;
                    // gameover
                    scene.showScene(Define.UI_GAMEOVER_MAIN);
                    UI.myEvent.AddListener(restart);
                }
                UI.setHp(now_hp, max_hp);
            }

            if (Input.GetKey("d"))
            {
                right_turn();
            }

            if (Input.GetKey("a"))
            {
                left_turn();
            }
        }
        else
        {
            speed = 0;
            rotate_speed = 0;
        }


    }

    void forward()
    {
        gameObject.GetComponent<Transform>().position += transform.forward * Time.deltaTime * speed;
    }

    void right_turn()
    {
        //Debug.Log("dKey");
        gameObject.GetComponent<Transform>().Rotate(0, rotate_speed, 0);
    }

    void left_turn()
    {
        //Debug.Log("aKey");
        gameObject.GetComponent<Transform>().Rotate(0, -rotate_speed, 0);
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
