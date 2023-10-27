using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeObstaculos : MonoBehaviour
{
    [SerializeField]
    private float tempoParaGerarFacil;
    [SerializeField]
    private float tempoParaGerarDificil;

    [SerializeField]
    private GameObject manualDeInstrucoes;
    private float cronometro;
    private ControleDeDificuldade ControleDeDificuldade;

    private void Start()
    {
        this.ControleDeDificuldade = GameObject.FindObjectOfType<ControleDeDificuldade>();
    }

    private void Awake()
    {
        this.cronometro = this.tempoParaGerarFacil;
    }

    void Update()
    {
        this.cronometro -= Time.deltaTime;
        if (this.cronometro <= 0)
        {
            GameObject.Instantiate(this.manualDeInstrucoes, this.transform.position, Quaternion.identity);
            this.cronometro = Mathf.Lerp(this.tempoParaGerarFacil, this.tempoParaGerarDificil, this.ControleDeDificuldade.Dificuldade);
        }
    }
}
