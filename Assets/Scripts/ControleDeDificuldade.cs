using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDeDificuldade : MonoBehaviour
{
    [SerializeField]
    private float TempoDificuldadeMaxima;
    private float TempoPassado;
    public float Dificuldade { get; private set; }

    void Update()
    {
        this.TempoPassado += Time.deltaTime;
        this.Dificuldade = this.TempoPassado / this.TempoDificuldadeMaxima;
        this.Dificuldade = Mathf.Min(1, this.Dificuldade);
    }

    public void ReiniciarDicifuldade()
    {
        this.Dificuldade = 0;
        this.TempoPassado = 0;
    }
}
