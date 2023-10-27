using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mao : MonoBehaviour
{
    private SpriteRenderer sprite;

    private void Awake()
    {
        this.sprite = this.GetComponent<SpriteRenderer>();

    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            this.OcultarMao();
        }
    }

    private void OcultarMao()
    {
        this.sprite.enabled = false;
    }
}
