using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scr_MenuManager : MonoBehaviour {

    public scr_Menu CurrentMenu;
    public scr_Menu CurrentPopup;

    public void Start()
    {
        ShowMenu(CurrentMenu);
    }

    public void ShowMenu(scr_Menu menu)
    {
        if (CurrentMenu != null)
            CurrentMenu.IsOpen = false;

        CurrentMenu = menu;
        CurrentMenu.IsOpen = true;
    }
    
    public void ShowPopUp(scr_Menu popup)
    {
        if (CurrentPopup != null)
            CurrentPopup.PopUp = false;

        CurrentPopup = popup;
        CurrentPopup.PopUp = true;
    }

    public void IniciarFase()
    {
        Application.LoadLevel("sce_Ranking");
    }
    
    public override void IniciarFase(int idfase)
    {
        Application.LoadLevel("sce_Fase" + idfase);
    }

}
