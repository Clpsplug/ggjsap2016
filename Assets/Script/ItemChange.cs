using UnityEngine;
using System.Collections;

public class ItemChange : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.tag);
        if (Input.GetKey("p"))
        {
            Debug.Log(col.gameObject.tag + "2");
            switch (col.gameObject.tag.ToString())
            {
                case "izanami":
                    if(ItemFlags.Items[0] == 1)
                    {
                        ItemFlags.Items[0] = 2;
                        Debug.Log("izanami");
                    }
                    break;
                                    
                case "sukunahiko":
                    if (ItemFlags.Items[1] == 1)
                    {
                        ItemFlags.Items[1] = 2;
                    }
                    break;

                case "shiotsutsi":
                    if (ItemFlags.Items[2] == 1)
                    {
                        ItemFlags.Items[2] = 2;
                    }
                    break;

                case "isotakeru":
                    if (ItemFlags.Items[3] == 1)
                    {
                        ItemFlags.Items[3] = 2;
                    }
                    break;

                case "takeminakata":
                    if (ItemFlags.Items[4] == 1)
                    {
                        ItemFlags.Items[4] = 2;
                    }
                    break;
            }
        }
    }
}
