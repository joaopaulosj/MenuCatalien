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
    private List<Pontuacao> _ListaSalvar;
    public InputField[] _inputNomes;
    public InputField[] _inputPontos;
    public int _pontuacao;
    private int _idText = -1;
    private int _idFase;
    private int _qtdFases;
    private TouchScreenKeyboard keyboard;
    #endregion

    #region - Start -
    void Start()
    {
    	try{
	        GameObject ControleJogo = GameObject.Find("ControleJogo");
            var scriptControle = ControleJogo.GetComponent("scrControleJogo") as scrControleJogo;
            _idFase = scriptControle._idfase;
            _qtdFases = scriptControle._qtdfases;
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
        try
        {
            _ListaRanking = RankingXML.Load(Path.Combine(Application.persistentDataPath, "ranking.xml")).Ranking;
        }
        catch (Exception ex)
        {
            _ListaRanking = new List<Pontuacao>();
        }
    }

    private void ExibirRanking()
    {
        _ListaRanking.Add(new Pontuacao { Nome = "???", Pontos = _pontuacao, IdFase = _idFase });
        _ListaSalvar = _ListaRanking;
        _ListaRanking = _ListaRanking.Where(x => x.IdFase == _idFase).OrderByDescending(x => x.Pontos).ToList();

        
        for (int i = 0; i < 3; i++)
        {
            var txtNome = _inputNomes[i];
            var txtPontos = _inputPontos[i];

            txtNome.text = "---";
            txtPontos.text = "---";    

            if(i + 1 <= _ListaRanking.Count)
            {
                txtNome.text = _ListaRanking[i].Nome;
                txtPontos.text = _ListaRanking[i].Pontos.ToString();
            }                        

            if (txtNome.text == "???")
            {
                _idText = i; //Encontra qual o text que tem o nome em branco, ou seja, onde o jogador vai inserir seu nome
                txtNome.interactable = true;
            }
        }

        //keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);

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

                _ListaSalvar.RemoveAll(x => x.Nome == "???");

                _ListaSalvar.Add(novoRecorde);
            }

            var ranking = new RankingXML();
            ranking.Save(_ListaSalvar, Application.persistentDataPath + "/ranking.xml");
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

        if (_idFase % 5 == 0)
        {
            Application.LoadLevel("sce_Home");
        }
        else
        {
            Application.LoadLevel("sce_Home");
        }
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
