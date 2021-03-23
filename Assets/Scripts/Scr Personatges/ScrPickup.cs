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
    /// VERSIÓ: 2.0
    /// CONTROL DE VERSIONS
    ///         1.0: ...es mouen.
    ///         2.0: colisionen
    /// ----------------------------------------------------------------------------------
    /// </summary>

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Collider2D col;
    [SerializeField] bool esRon;
    [SerializeField] bool esBarril;
    [SerializeField] bool esMoneda;

    Vector2 moviment = new Vector2();
    public GameObject control;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        moviment.x = -2;
    }

    // Update is called once per frame
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
                control.GetComponent<ScrControlGame>().monedes += 1;
            }

            Destroy(gameObject);
        }
    }
}
