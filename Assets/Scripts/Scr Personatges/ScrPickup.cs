using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrPickup : MonoBehaviour
{
    /// <summary>
    /// ----------------------------------------------------------------------------------
    /// DESCRIPCIÓ
    ///         Script utilitzat per moure els pickups
    /// AUTOR:  Eric Clot Martín
    /// DATA:   21/03/2021
    /// VERSIÓ: 3.0
    /// CONTROL DE VERSIONS
    ///         1.0: Es creen i es mouen correctament.
    ///         2.0: Ara colisionen correctament.
    ///         3.0: Lidia: neteja de codi i s'afegeix so.
    /// ----------------------------------------------------------------------------------
    /// </summary>

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Collider2D col;
    [SerializeField] bool esRon;
    [SerializeField] bool esBarril;
    [SerializeField] bool esMoneda;

    [SerializeField] AudioClip so;

    Vector2 moviment = new Vector2();
    public GameObject control;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        moviment.x = -2;
    }

    void Update()
    {
        rb.velocity = moviment;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (esRon)
            {
                control.GetComponent<ScrControlGame>().vida += 1;
            }
            else if (esBarril)
            {
                control.GetComponent<ScrControlGame>().municio += 5;
            }
            else if (esMoneda)
            {
                control.GetComponent<ScrControlGame>().monedes += 5;
            }

            if(so) AudioSource.PlayClipAtPoint(so, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}
