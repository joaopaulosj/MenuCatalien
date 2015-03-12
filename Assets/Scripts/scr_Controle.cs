using UnityEngine;
using System.Collections;

public class scr_Controle : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//switch case com todas as telas
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();
	}
}
