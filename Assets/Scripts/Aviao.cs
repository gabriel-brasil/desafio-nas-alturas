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

    private void Awake()
    {
        this.fisica = this.GetComponent<Rigidbody2D>();
        this.posicaoInicial = this.transform.position;
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
            this.Impulsionar();
        }
    }

    private void Impulsionar()
    {
        this.fisica.velocity = Vector2.zero;
        this.fisica.AddForce(Vector2.up * this.forca, ForceMode2D.Impulse);
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
