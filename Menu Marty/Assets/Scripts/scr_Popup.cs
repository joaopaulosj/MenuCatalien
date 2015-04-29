using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class scr_Popup : MonoBehaviour
{

    private Animator _animator;
    private CanvasGroup _canvasGroup;
    public Text titulo;
    private GameObject _ControleJogo;

    public bool IsOpen
    {
        get { return _animator.GetBool("IsOpen"); }
        set { _animator.SetBool("IsOpen", value); }
    }

    public void Awake()
    {
        _animator = GetComponent<Animator>();
        _canvasGroup = GetComponent<CanvasGroup>();

        var rect = GetComponent<RectTransform>();
        rect.offsetMax = rect.offsetMin = new Vector2(0, 0);

        _ControleJogo = GameObject.Find("ControleJogo");        
    }

    public void Update()
    {
        try
        {
            var scriptControle = _ControleJogo.GetComponent("scrControleJogo") as scrControleJogo;
            //titulo.text = " Fase " + scriptControle._idfase;
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }

        if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Open"))
        {
            _canvasGroup.blocksRaycasts = _canvasGroup.interactable = false;
        }
        else
        {
            _canvasGroup.blocksRaycasts = _canvasGroup.interactable = true;
        }
    }
}
