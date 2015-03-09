using UnityEngine;
using System.Collections;

public class ControleJogo : MonoBehaviour {
	
	private int _idfase = 0;
	private _qtdfases = 0;
	private int _pontuacao = 0;
	
	#region - Start -
	void Start () 
	{
	
	}
	#endregion
	
	#region - Getters/Setters -
	
	public void SetIdFase(int idfase)
	{
		_idfase = idfase;
	}
	
	public int GetIdFase()
	{
		return _idfase;
	}
	
	public void SetQtdFases(int qtdfases)
	{
		_qtdfases = qtdfases;
	}
	
	public int GetQtdFases()
	{
		return _qtdfases;
	}
	
	public void SetPontuacao(int pontuacao)
	{
		_pontuacao = pontuacao;
	}
	
	public int GetPontuacao()
	{
		return _pontuacao;
	}
	#endregion
	
}
