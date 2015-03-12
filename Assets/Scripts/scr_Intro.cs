using UnityEngine;
using System.Collections;

public class scr_Intro : MonoBehaviour {

    float time;

	// Use this for initialization
	void Start () {
        time = 0;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        if (time >= 2)
            Application.LoadLevel("sce_Home");
	}
}
