using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scr_MenuManager : MonoBehaviour {

    public scr_Menu CurrentMenu;
    public scr_Popup CurrentPopup;

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

        if (CurrentPopup != null)
        {
            CurrentPopup.IsOpen = false;
        }
    }

    public void ShowPopup(scr_Popup popup)
    {
        if (CurrentPopup != null)
            CurrentPopup.IsOpen = false;

        CurrentPopup = popup;
        CurrentPopup.IsOpen = true;

        var canvasgroup = CurrentMenu.GetComponent<CanvasGroup>();
        canvasgroup.interactable = canvasgroup.blocksRaycasts = false;
    }

    public void ClosePopup(scr_Popup popup)
    {
        if (CurrentPopup != null)
            CurrentPopup.IsOpen = true;

        CurrentPopup = popup;
        CurrentPopup.IsOpen = false;

        var canvasgroup = CurrentMenu.GetComponent<CanvasGroup>();
        canvasgroup.interactable = canvasgroup.blocksRaycasts = true;
    }
    
    public void setFase(int fase)
    {
        GameObject ControleJogo = GameObject.Find("ControleJogo");
        var scriptControle = ControleJogo.GetComponent("scrControleJogo") as scrControleJogo;
        scriptControle._idfase = fase;
    }

    public void IniciarFase()
    {
        GameObject ControleJogo = GameObject.Find("ControleJogo");
        var scriptControle = ControleJogo.GetComponent("scrControleJogo") as scrControleJogo;
        var idfase = scriptControle._idfase;
        //Application.LoadLevel("sce_Fase" + idfase);
        Application.LoadLevel("sce_Ranking");
    }

}
