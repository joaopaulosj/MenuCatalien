using UnityEngine;
using System.Collections;

public class ButtonClickMenu : MonoBehaviour {

	private AudioSource au_buttonclick;
	private AudioSource au_returnclick;



	// Use this for initialization
	void Start () {
	
		#region button click

			au_buttonclick = (AudioSource)gameObject.AddComponent <AudioSource>();
			AudioClip myAudioClip;
			myAudioClip = (AudioClip)Resources.Load("SFX/Click/ButtonClick");
			au_buttonclick.clip = myAudioClip;
			au_buttonclick.loop = false;
			au_buttonclick.playOnAwake = false;
			
		#endregion

		#region return click

			au_returnclick = (AudioSource)gameObject.AddComponent <AudioSource>();
			AudioClip myAudioClip2;
			myAudioClip2 = (AudioClip)Resources.Load("SFX/Click/ReturnClick");
			au_returnclick.clip = myAudioClip2;
			au_returnclick.loop = false;
			au_returnclick.playOnAwake = false;

		#endregion
		

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick (){

		if (this.gameObject.tag == "btn_Botao") {

			setClickButtonOn ();

		}

		if (this.gameObject.tag == "btn_Retorno") {
			
			setReturnButtonOn ();
			
		}
		
	}
	
	public void setClickButtonOn()
	{
		au_buttonclick.Play();
	}

	public void setReturnButtonOn()
	{
		au_returnclick.Play();
	}
}
