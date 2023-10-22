using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiretorDeCena : MonoBehaviour
{
    [SerializeField]
    private GameObject imagemGabeOver;
    private Aviao aviao;
    private Pontuacao pontuacao;

    private void Start()
    {
        this.aviao = GameObject.FindAnyObjectByType<Aviao>();
        this.pontuacao = GameObject.FindObjectOfType<Pontuacao>();
    }

    public void FinalizarJogo()
    {
        Time.timeScale = 0;
        this.imagemGabeOver.SetActive(true);
    }

    public void ReiniciarJogo()
    {
        Time.timeScale = 1;
        this.imagemGabeOver.SetActive(false);
        this.aviao.Reiniciar();
        this.DestruirObstaculos();
        this.pontuacao.zerarPonto();

    }

    private void DestruirObstaculos()
    {
        Obstaculo[] obstaculos = GameObject.FindObjectsOfType<Obstaculo>();
        foreach (Obstaculo obstaculo in obstaculos)
        {
            obstaculo.DestruirObstaculo();
        }

    }

}
