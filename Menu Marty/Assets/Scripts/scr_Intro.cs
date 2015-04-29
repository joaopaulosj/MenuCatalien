using UnityEngine;
using System.Collections;

public class scr_Intro : MonoBehaviour {

    public float time = 2;

	void Start () {
	}
	

	void Update () {
        time -= Time.deltaTime;

        if (time <= 0)
            Application.LoadLevel("sce_Home");
	}
}
