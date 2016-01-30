using UnityEngine;
using System.Collections;

public class CreateItem : MonoBehaviour {

    public GameObject sake;
    int i;

	// Use this for initialization
	void Start () {
        for (i = 0; i <= 20; ++i)
        {
            //オブジェクトの座標
            float x = Random.Range(-20.0f, 20.0f);  //左が最少値、右が最大値
            float z = Random.Range(-20.0f, 20.0f);

            //オブジェクトを生産
            Instantiate(sake, new Vector3(x, 1, z), Quaternion.identity);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
