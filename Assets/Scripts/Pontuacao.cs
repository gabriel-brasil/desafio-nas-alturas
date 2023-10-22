using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pontuacao : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textoPontuacao;
    private int pontuacao;
    private AudioSource audioPontuacao;

    private void Awake()
    {
        this.audioPontuacao = this.GetComponent<AudioSource>();
    }

    public void adicionarPonto()
    {
        this.pontuacao++;
        this.atualizarTextoPontuacao();
        this.audioPontuacao.Play();
    }

    public void zerarPonto()
    {
        this.pontuacao = 0;
        this.atualizarTextoPontuacao();
    }

    private void atualizarTextoPontuacao()
    {
        this.textoPontuacao.text = this.pontuacao.ToString();
    }

}