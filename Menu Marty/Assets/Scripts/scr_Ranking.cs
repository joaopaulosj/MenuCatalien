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
    private GameObject ControleJogo;
    #endregion

    #region - Start -
    void Start()
    {
    	try{
	        ControleJogo = GameObject.Find("ControleJogo");
            var scriptControle = ControleJogo.GetComponent("scrControleJogo") as scrControleJogo;
            _pontuacao = scriptControle._pontuacao;
            //_pontuacao = 465;
            _idFase = scriptControle._idfase;
            _qtdFases = scriptControle._qtdfases;
    	}catch(Exception ex){
    		Debug.Log(ex);
    	}
    	
        
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

        if (_idText >= 0)
        {
            StartCoroutine(Flash(3f, 0.5f));
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
            Debug.Log("Erro ao salvar ranking - " + ex);
        }
    }
    #endregion

    #region - Avançar Fase - 
    public void AvancarFase(int idFase)
    {
        SalvarRanking();        

        if (_idFase < _qtdFases)
        {
            var scriptControle = ControleJogo.GetComponent("scrControleJogo") as scrControleJogo;
            scriptControle._idfase ++;
            Application.LoadLevel("sce_Fase" + (scriptControle._idfase));
        }
        else
            Application.LoadLevel("sce_Home");
    }
    #endregion

    #region - Abrir Menu -
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
    #endregion

    #region - Reiniciar Fase -
    public void ReiniciarFase()
    {
        SalvarRanking();
        Application.LoadLevel("sce_Fase" + _idFase);
    }
    #endregion   

    IEnumerator Flash(float time, float intervalTime)
    {
        float elapsedTime = 0f;
        bool alfa = true;

        if (_inputNomes[_idText].text == "???")
        {
            while (elapsedTime < time)
            {
                if (alfa)
                {
                    _inputNomes[_idText].textComponent.color = new Color(102, 255, 102, 0);
                    _inputPontos[_idText].textComponent.color = new Color(102, 255, 102, 0);
                }
                else
                {
                    _inputNomes[_idText].textComponent.color = new Color(102, 255, 102, 255);
                    _inputPontos[_idText].textComponent.color = new Color(102, 255, 102, 255);
                }

                elapsedTime += Time.deltaTime;
                alfa = !alfa;
                yield return new WaitForSeconds(intervalTime);
            }
        }
    }
}