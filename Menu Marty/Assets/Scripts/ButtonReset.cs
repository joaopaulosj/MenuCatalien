using UnityEngine;
using System.Collections;

public class ButtonReset : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Clicou()
	{
		Application.LoadLevel("Fase1");
	}
}
