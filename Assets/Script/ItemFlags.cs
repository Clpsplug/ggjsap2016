using UnityEngine;
using System.Collections;

public class ItemFlags : MonoBehaviour {

    public string now_col;

    public static int[] Items = new int[5];
    // 1果物
    // 2お酒
    // 3塩
    // 4魚
    // 5刀

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionStay(Collision col)
    {
        now_col = col.gameObject.tag.ToString();
        switch (col.gameObject.tag.ToString())
        {
            case "orange":
                //果物
                Items[0] = 1;
                //Debug.Log(Items[0]+col.gameObject.tag);
                break;

            case "osake":
                //お酒
                Items[1] = 1;
                //Debug.Log(Items[1] + col.gameObject.tag);
                break;

            case "salt":
                //塩
                Items[2] = 1;
                //Debug.Log(Items[2] + col.gameObject.tag);
                break;

            case "fish":
                //魚
                Items[3] = 1;
                //Debug.Log(Items[3] + col.gameObject.tag);
                break;

            case "katana":
                //刀
                Items[4] = 1;
                //Debug.Log(Items[4] + col.gameObject.tag);
                break;

            case "izanami":
                Debug.Log(col.gameObject.tag);
                if (ItemFlags.Items[0] == 1 && Input.GetKey("z"))
                {
                    ItemFlags.Items[0] = 2;
                    Debug.Log("izanami2");
                }
                break;

            case "sukunahiko":
                Debug.Log(col.gameObject.tag);
                if (ItemFlags.Items[1] == 1 && Input.GetKey("z"))
                {
                    ItemFlags.Items[1] = 2;
                    Debug.Log("sukunahiko2");
                }
                break;

            case "shiotsuti":
                Debug.Log(col.gameObject.tag);
                if (ItemFlags.Items[2] == 1 && Input.GetKey("z"))
                {
                    ItemFlags.Items[2] = 2;
                    Debug.Log("shiotsuti2");
                }
                break;

            case "isotakeru":
                Debug.Log(col.gameObject.tag);
                if (ItemFlags.Items[3] == 1 && Input.GetKey("z"))
                {
                    ItemFlags.Items[3] = 2;
                    Debug.Log("isotakeru2");
                }
                break;

            case "takeminakata":
                Debug.Log(col.gameObject.tag);
                if (ItemFlags.Items[4] == 1 && Input.GetKey("z"))
                {
                    ItemFlags.Items[4] = 2;
                    Debug.Log("takeminakata2");
                }
                break;
        }
    }
}
