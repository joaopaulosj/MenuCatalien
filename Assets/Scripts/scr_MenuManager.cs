using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scr_MenuManager : MonoBehaviour {

    public scr_Menu CurrentMenu;

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

    public void IniciarFase()
    {
        Application.LoadLevel("sce_Ranking");
    }

}
