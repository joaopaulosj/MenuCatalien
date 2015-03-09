using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

public class scr_Ranking : MonoBehaviour
{

    #region - Propriedades -
    private List<Pontuacao> _ListaRanking;
    public InputField[] _inputNomes;
    public InputField[] _inputPontos;
    public int _pontuacao;
    private int _idText = -1;
    private int _idFase;
    private int _qtdFases;
    #endregion

    #region - Start -
    void Start()
    {
    	try{
	        GameObject ControleJogo = GameObject.Find("ControleJogo");
			scriptControle = ControleJogo.GetComponent(scrControleJogo);
			_idFase = scriptControle.GetIdFase();
			_qtdFases = scriptControle.GetQtdFases();
    	}catch(Exception ex){
    		Debug.Log(ex);
    	}
    	
        _pontuacao = (int)(UnityEngine.Random.Range(3000, 5000));
        CarregarRanking();
        ExibirRanking();

    }
    #endregion

    #region - Ranking -
    private void CarregarRanking()
    {
        _ListaRanking = RankingXML.Load(Path.Combine(Application.persistentDataPath, "ranking.xml")).Ranking;
    }

    private void ExibirRanking()
    {
        _ListaRanking.Add(new Pontuacao { Nome = "???", Pontos = _pontuacao });
        _ListaRanking = _ListaRanking.OrderByDescending(x => x.Pontos).ToList();


        for (int i = 0; i < 3; i++)
        {
            var nome = _inputNomes[i];
            var pontos = _inputPontos[i];

            nome.text = _ListaRanking[i].Nome;
            pontos.text = _ListaRanking[i].Pontos.ToString();

            if (nome.text == "???")
            {
                _idText = i; //Encontra qual o text que tem o nome em branco, ou seja, onde o jogador vai inserir seu nome
                nome.interactable = true;
            }
        }
    }

    private void SalvarRanking()
    {
        try
        {
            if(_idText >= 0)
            {
                var novoNome = _inputNomes[_idText].text;

                var novoRecorde = new Pontuacao
                {
                    Nome = novoNome == "???" ? "---" : novoNome,
                    Pontos = _pontuacao,
                    Data = DateTime.Now,
                    IdFase = _idFase
                };

                var substituir = _ListaRanking.RemoveAll(x => x.Nome == "???");

                _ListaRanking.Add(novoRecorde);
            }

            var ranking = new RankingXML();
            ranking.Save(_ListaRanking, Application.persistentDataPath +  "/ranking.xml");
            Debug.Log("Ranking.xml salvo em " + Application.persistentDataPath);
        }
        catch (Exception ex)
        {
            Debug.Log("Erro ao salvar ranking");
        }
    }
    #endregion

    #region - Botões -
    public void AvancarFase(int idFase)
    {
        SalvarRanking();
        
        if(_idFase < _qtdFases)
        	Application.LoadLevel("sce_Fase" + (_idFase + 1));
        else
        	Application.LoadLevel("sce_Niveis");
    }

    public void AbrirMenu()
    {
        SalvarRanking();
        
        if(_idFase % 5 == 0)
        	Application.LoadLevel("sce_Niveis");
        else
        	Application.LoadLevel("sce_Fases");
    }

    public void ReiniciarFase()
    {
        SalvarRanking();
        Application.LoadLevel("sce_Fase" + _idFase);
    }
    #endregion

    #region - Update -
    void Update()
    {

    }
    #endregion
}
