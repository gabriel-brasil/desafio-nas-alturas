using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pontuacao : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textoPontuacao;
    public int Pontos { get; private set; }
    private AudioSource audioPontuacao;

    private void Awake()
    {
        this.audioPontuacao = this.GetComponent<AudioSource>();
    }

    public void adicionarPonto()
    {
        this.Pontos++;
        this.atualizarTextoPontuacao();
        this.audioPontuacao.Play();
    }

    public void zerarPonto()
    {
        this.Pontos = 0;
        this.atualizarTextoPontuacao();
    }

    private void atualizarTextoPontuacao()
    {
        this.textoPontuacao.text = this.Pontos.ToString();
    }

    public void salvarRecorde()
    {
        if (PlayerPrefs.GetInt("recorde") < this.Pontos)
        {
            PlayerPrefs.SetInt("recorde", this.Pontos);
        }
    }
}