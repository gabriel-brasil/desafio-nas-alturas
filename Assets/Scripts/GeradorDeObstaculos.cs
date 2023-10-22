using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeObstaculos : MonoBehaviour
{
    [SerializeField]
    private float tempoParaGerar;
    private float cronometro;
    [SerializeField]
    private GameObject manualDeInstrucoes;

    private void Awake()
    {
        this.cronometro = this.tempoParaGerar;
    }

    void Update()
    {
        this.cronometro -= Time.deltaTime;
        if (this.cronometro <= 0)
        {
            this.cronometro = Random.Range(0.5f, this.tempoParaGerar);
            GameObject.Instantiate(this.manualDeInstrucoes, this.transform.position, Quaternion.identity);
        }
    }
}
