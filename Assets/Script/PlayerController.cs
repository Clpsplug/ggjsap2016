using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("w"))
        {
            gameObject.GetComponent<Transform>().position += transform.forward * Time.deltaTime * speed;
        }

        if (Input.GetKey("d"))
        {
            gameObject.GetComponent<Transform>().Rotate(0, 50.0f*Time.deltaTime, 0);
        }

        if (Input.GetKey("a"))
        {
            gameObject.GetComponent<Transform>().Rotate(0, -50.0f*Time.deltaTime, 0);
        }
    }
}
