using UnityEngine;
using System.Collections;

public class scrControleJogo : MonoBehaviour
{

    #region - Propriedades -
    public int _idfase { get; set; }
	public int _qtdfases { get; set; }
	public int _idnivel { get; set; }
	public int _qtdniveis { get; set; }
	public int _pontuacao { get; set; }
    #endregion

    void Start () 
	{
        _qtdfases = 5;
        _qtdniveis = 1;
	}

    void Awake() 
    {
        DontDestroyOnLoad(this);
    }
	
	
}
