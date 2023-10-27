using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InterfaceGameOver : MonoBehaviour
{
    [SerializeField]
    private TMP_Text TextoRecorde;
    [SerializeField]
    private GameObject imagemGameOver;
    [SerializeField]
    private Image posicaoMedalha;
    [SerializeField]
    private Sprite medalhaOuro;
    [SerializeField]
    private Sprite medalhaPrata;
    [SerializeField]
    private Sprite medalhaBronze;

    private int recorde;
    private Pontuacao pontuacao;


    private void Start()
    {
        this.pontuacao = GameObject.FindObjectOfType<Pontuacao>();
    }

    private void atualizarRecorde()
    {
        this.recorde = PlayerPrefs.GetInt("recorde");
        this.TextoRecorde.text = recorde.ToString();
        this.VerificarCorMedalha();
    }

    public void mostrarGameOver()
    {
        this.atualizarRecorde();
        this.imagemGameOver.SetActive(true);
    }

    public void ocultarGameOver()
    {
        this.imagemGameOver.SetActive(false);
    }

    private void VerificarCorMedalha()
    {
        int pontos = this.pontuacao.Pontos;

        if (pontos > this.recorde - 5)
        {
            this.posicaoMedalha.sprite = this.medalhaOuro;
        }
        else if (pontos > this.recorde / 2)
        {
            this.posicaoMedalha.sprite = this.medalhaPrata;
        }
        else
        {
            this.posicaoMedalha.sprite = this.medalhaBronze;
        }
    }
}
