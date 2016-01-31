using UnityEngine;
using System.Collections;

public class ItemFlags : MonoBehaviour {

    string now_col;
    int i = 0;

    public UICanvasScript UI;
    public SceneControllerScript scene;

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

    void OnTriggerStay(Collider col)
    {
        now_col = col.gameObject.tag.ToString();
        switch (now_col)
        {
            case "orange":
                //果物
                if(Items[0] == 1 || Items[0] == 4)
                {
                    return;
                    break;
                }
                if (col.name == "Fruits")
                {
                    Debug.Log("本物の果物");
                    Items[0] = 1;
                    UI.updateItem(0, 1);
                    Destroy(GameObject.Find("Fruits"));
                }
                else
                {
                    Debug.Log("偽物の果物");
                    Items[0] = 4;
                    UI.updateItem(0, 4);
                    Destroy(GameObject.Find("Fake_Fruits"));
                }
                //Debug.Log(Items[0]+col.gameObject.tag);
                break;

            case "osake":
                //お酒
                if (Items[1] == 1 || Items[1] == 4)
                {
                    return;
                    break;
                }
                if (col.name == "Liquor")
                {
                    Debug.Log("本物の酒");
                    Items[1] = 1;
                    UI.updateItem(1, 1);
                    Destroy(GameObject.Find("Liquor"));
                }
                else
                {
                    Debug.Log("偽物の酒");
                    Items[1] = 4;
                    UI.updateItem(1, 4);
                    Destroy(GameObject.Find("Fake_Liquor"));
                }
                //Debug.Log(""+ Items[1] + col.gameObject.tag);
                break;

            case "salt":
                //塩
                if (Items[2] == 1 || Items[2] == 4)
                {
                    return;
                    break;
                }
                if (col.name == "Salt")
                {
                    Debug.Log("本物の塩");
                    Items[2] = 1;
                    UI.updateItem(2, 1);
                    Destroy(GameObject.Find("Salt"));
                }
                else
                {
                    Debug.Log("偽物の塩");
                    Items[2] = 4;
                    UI.updateItem(2, 4);
                    Destroy(GameObject.Find("Fake_Salt"));
                }
                //Debug.Log(Items[2] + col.gameObject.tag);
                break;

            case "fish":
                //魚
                if (Items[3] == 1 || Items[3] == 4)
                {
                    return;
                    break;
                }
                if (col.name == "Fish")
                {
                    Debug.Log("本物の魚");
                    Items[3] = 1;
                    UI.updateItem(3, 1);
                    Destroy(GameObject.Find("Fish"));
                }
                else
                {
                    Debug.Log("偽物の魚");
                    Items[3] = 4;
                    UI.updateItem(3, 4);
                    Destroy(GameObject.Find("Fake_Fish"));
                }
                //Debug.Log(Items[3] + col.gameObject.tag);
                break;

            case "katana":
                //刀
                if (Items[4] == 1 || Items[4] == 4)
                {
                    return;
                    break;
                }
                if (col.name == "Katana")
                {
                    Debug.Log("本物の刀");
                    Items[4] = 1;
                    UI.updateItem(4, 1);
                    Destroy(GameObject.Find("Katana"));
                }
                else
                {
                    Debug.Log("偽物の刀");
                    Items[4] = 4;
                    UI.updateItem(4, 4);
                    Destroy(GameObject.Find("Fake_Katana"));
                }
                //Debug.Log(Items[4] + col.gameObject.tag);
                break;

            case "izanami":
                if (ItemFlags.Items[0] == 1 && Input.GetKey("z"))
                {
                    ItemFlags.Items[0] = 2;
                    UI.updateItem(0, 2);
                    Debug.Log("izanami2");
                }
                else
                {
                    ItemFlags.Items[0] = 0;
                    UI.updateItem(0, 0);
                }
                break;

            case "sukunahiko":
                if (ItemFlags.Items[1] == 1 && Input.GetKey("z"))
                {
                    ItemFlags.Items[1] = 2;
                    UI.updateItem(1, 2);
                    Debug.Log("sukunahiko2");
                }
                else
                {
                    ItemFlags.Items[1] = 0;
                    UI.updateItem(1, 0);
                }
                break;

            case "shiotsuti":
                if (ItemFlags.Items[2] == 1 && Input.GetKey("z"))
                {
                    ItemFlags.Items[2] = 2;
                    UI.updateItem(2, 2);
                    Debug.Log("shiotsuti2");
                }
                else
                {
                    ItemFlags.Items[2] = 0;
                    UI.updateItem(2, 0);
                }
                break;

            case "isotakeru":
                if (ItemFlags.Items[3] == 1 && Input.GetKey("z"))
                {
                    ItemFlags.Items[3] = 2;
                    UI.updateItem(3, 2);
                    Debug.Log("isotakeru2");
                }
                else
                {
                    ItemFlags.Items[3] = 0;
                    UI.updateItem(3, 0);
                }
                break;

            case "takeminakata":
                if (ItemFlags.Items[4] == 1 && Input.GetKey("z"))
                {
                    ItemFlags.Items[4] = 2;
                    UI.updateItem(4, 2);
                    Debug.Log("takeminakata2");
                }
                else
                {
                    ItemFlags.Items[4] = 0;
                    UI.updateItem(4, 0);
                }
                break;
        }

        if (col.gameObject.tag == "kamidana" && Input.GetKey("z"))
        {
            while (i <= 4)
            {
                if (ItemFlags.Items[i] == 2)
                {
                    ++i;
                }
            }

            if (i == 5)
            {
                scene.showScene(Define.UI_CLEAR_MAIN);
                Debug.Log("game_clear");
            }
            else
            {
                Debug.Log("out");
            }
        }
    }

    //public int GetItemArray(int inItemNumber)
    //{
    //    switch (inItemNumber)
    //    {
        
    //    }
    //    return 0;
    //}
}
