using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiretorDeCena : MonoBehaviour
{
    private Aviao aviao;
    private Pontuacao pontuacao;
    private InterfaceGameOver interfaceGameOver;
    private ControleDeDificuldade ControleDeDificuldade;

    private void Start()
    {
        this.aviao = GameObject.FindObjectOfType<Aviao>();
        this.pontuacao = GameObject.FindObjectOfType<Pontuacao>();
        this.interfaceGameOver = GameObject.FindObjectOfType<InterfaceGameOver>();
        this.ControleDeDificuldade = GameObject.FindObjectOfType<ControleDeDificuldade>();
    }

    public void FinalizarJogo()
    {
        Time.timeScale = 0;
        this.pontuacao.salvarRecorde();
        this.interfaceGameOver.mostrarGameOver();
        this.ControleDeDificuldade.ReiniciarDicifuldade();
    }

    public void ReiniciarJogo()
    {
        Time.timeScale = 1;
        this.aviao.Reiniciar();
        this.DestruirObstaculos();
        this.pontuacao.zerarPonto();
        this.interfaceGameOver.ocultarGameOver();
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
