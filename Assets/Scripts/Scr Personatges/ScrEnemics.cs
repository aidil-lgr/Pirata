using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrEnemics : MonoBehaviour
{

    /// <summary>
    /// ----------------------------------------------------------------------------------
    /// DESCRIPCIÓ
    ///         Script utilitzat per controlars els vaixells enemics.
    /// AUTOR:  Lídia García Romero
    /// DATA:   15/03/2021
    /// VERSIÓ: 1.0
    /// CONTROL DE VERSIONS
    ///         1.0: 
    /// ----------------------------------------------------------------------------------
    /// </summary>

    [SerializeField] float velX = -5f;
    float velY = 0f;
    float desfase; //pel tipus de moviment sinosuidal
    Vector2 moviment = new Vector2();

    Rigidbody2D rb;
    Collider2D col;
    Renderer rend;

    [SerializeField] int tipusMoviment = 1; //determinara de quina manera es mourà el vaixell

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velY = Random.Range(-2f, 2);
        desfase = Random.Range(0, 360);

        rend = GetComponent<Renderer>();
        col = GetComponent<Collider2D>();
        col.enabled = false; //que comencin amb el collider desactivat fins que no apareguin per pantalla

        if (tipusMoviment == 0) //si posem 0, serà moviment d'un tipus aleatori
        {
            tipusMoviment = Random.Range(1, 3 + 1); //Hi ha 3 tipus de moviment en total.
        }
    }

    void Update()
    {
        CalculaMoviment(tipusMoviment);
        rb.velocity = moviment;
        if (ScrControlGame.EsVisibleDesde(rend, Camera.main))
        {
            col.enabled = true;
        }
    }

    void CalculaMoviment(int tipus)
    {
        switch (tipus)
        {
                
                
            case 1: //moviment a velocitat x constant
                moviment.x = velX;
                moviment.y = 0;
                break;

            case 2: //moviment diagonal amb y aleatoria
                moviment.x = velX;
                moviment.y = velY;
                break;

            case 3: //moviment siniusoidal
                moviment.x = velX;

                float amplitud = 1f, freq = 2;
                moviment.y = amplitud * Mathf.Sin(freq * Time.time + desfase);
                break;


        }
    }

    void Destruccio() //PROTOTIP com es destrueix l'objecte
    {
        Destroy(gameObject);
    }
}
