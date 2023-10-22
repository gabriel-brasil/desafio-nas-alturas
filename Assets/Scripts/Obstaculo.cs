using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    [SerializeField]
    private float velocidade = 5;
    [SerializeField]
    private float variacaoPosicaoY = 2;
    private Vector3 posicaoAviao;
    private bool pontuou = false;
    private Pontuacao pontuacao;

    private void Awake()
    {
        this.transform.Translate(Vector3.up * Random.Range(-variacaoPosicaoY, variacaoPosicaoY));
    }

    private void Start()
    {
        this.posicaoAviao = GameObject.FindObjectOfType<Aviao>().transform.position;
        this.pontuacao = GameObject.FindObjectOfType<Pontuacao>();
    }

    private void Update()
    {
        this.transform.Translate(Vector3.left * this.velocidade * Time.deltaTime);
        if (this.transform.position.x < posicaoAviao.x && !this.pontuou)
        {
            this.pontuou = true;
            this.pontuacao.adicionarPonto();
        }
    }

    private void OnTriggerEnter2D(Collider2D outro)
    {
        this.DestruirObstaculo();
    }

    public void DestruirObstaculo()
    {
        GameObject.Destroy(this.gameObject);
    }
}
