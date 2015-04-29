using UnityEngine;
using System.Collections;

public class scr_Controle : MonoBehaviour {


	void Start () 
    {
	}
	

	void Update () 
    {
		
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();
	}
}
