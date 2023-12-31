using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aviao : MonoBehaviour
{
    private Rigidbody2D fisica;
    [SerializeField]
    private float forca;
    private DiretorDeCena diretor;
    private Vector3 posicaoInicial;
    private bool pular = true;
    private bool deveImpulsionar = false;
    private Animator animacao;

    private void Awake()
    {
        this.fisica = this.GetComponent<Rigidbody2D>();
        this.posicaoInicial = this.transform.position;
        this.animacao = this.GetComponent<Animator>();
    }

    private void Start()
    {
        this.diretor = GameObject.FindAnyObjectByType<DiretorDeCena>();
        this.fisica.freezeRotation = true;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && this.pular)
        {
            this.deveImpulsionar = true;
        }
        this.animacao.SetFloat("VelocidadeY", this.fisica.velocity.y);
    }

    private void FixedUpdate()
    {
        if (this.deveImpulsionar)
        {
            this.Impulsionar();
        }
    }

    private void Impulsionar()
    {
        this.fisica.velocity = Vector2.zero;
        this.fisica.AddForce(Vector2.up * this.forca, ForceMode2D.Impulse);
        this.deveImpulsionar = false;
    }

    private void OnCollisionEnter2D(Collision2D colisao)
    {
        this.pular = false;
        this.diretor.FinalizarJogo();
    }

    public void Reiniciar()
    {
        this.transform.position = this.posicaoInicial;
        this.fisica.simulated = true;
        this.pular = true;
    }
}
