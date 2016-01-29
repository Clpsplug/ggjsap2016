using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("w"))
        {
            gameObject.GetComponent<Transform>().position += new Vector3(0.1f * Time.fixedTime, 0, 0);
        }
	}
}
