using UnityEngine;
using System.Collections;

public class ControleJogo : MonoBehaviour {
	
	private int _idfase = 0;
	private int _qtdfases = 5;
	private int _idnivel = 0;
	private int _qtdniveis = 1;
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
	
	public void SetQtdNiveis(int qtdniveis)
	{
		_qtdniveis = qtdniveis;
	}
	
	public int GetQtdNiveis()
	{
		return _qtdniveis;
	}
	
	public void SetIdNivel(int idnivel)
	{
		_idnivel = idnivel;
	}
	
	public int GetIdNivel()
	{
		return _idnivel;
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
