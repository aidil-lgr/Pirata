using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrKraken : MonoBehaviour
{
    /// <summary>
    /// ----------------------------------------------------------------------------------
    /// DESCRIPCIÓ
    ///         Script utilitzat per determinar el comportament del Kraken.
    /// AUTOR:  Eric Clot Martín
    /// DATA:   21/03/2021
    /// VERSIÓ: 1.0
    /// CONTROL DE VERSIONS
    ///         1.0: 
    /// ----------------------------------------------------------------------------------
    /// </summary>
    

    [SerializeField] float velX = 1f, velY = 1;
    Vector2 moviment = new Vector2();
    Rigidbody2D rb;

    [SerializeField] float elast = 1;  // per a funció 'seguir player'

    GameObject player;
    [SerializeField] GameObject explosio; // sist. partícules destrucció  *CAMBIAR*


    // ********************** Shooting ************************
    [SerializeField] Transform tentacle1, tentacle2, tentacle3, tentacle4, tentacle5, tentacle6;  
    [SerializeField] GameObject tinta;
    [SerializeField] float cadenciaMin = 2f, cadenciaMax = 20f; // tiempo entre disparos
    float crono;
    bool isDestroyed = false;
    float nombre_tintes;
    Renderer r;
    Collider2D col;


    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        r = GetComponent<Renderer>();
        col = GetComponent<Collider2D>();
        col.enabled = false;

        velY = Random.Range(-2f, 2f);
        player = GameObject.FindGameObjectWithTag("Player");
        crono = Random.Range(cadenciaMin, cadenciaMax); // Preparem primer tret

    }

    void Update()
    {
        if (ScrControlGame.EsVisibleDesde(r, Camera.main))
        {
            col.enabled = true;
            crono -= Time.deltaTime;
            if ((crono <= 0) && (transform.position.x < 4))
            {
                nombre_tintes = Random.Range(0, 10); //quants trets de tinta dispararà
                Dispara(); //el boss dispararà quan arribi a x = 4
            }
        }
    }

    void Dispara()
    {
        GameObject p1;
        p1 = Instantiate(tinta, tentacle1.position, tentacle1.rotation);        //dispara d'1 a 6 trets de tinta alhora
        p1.transform.Rotate(0, 0, 0);

        if (nombre_tintes > 5)
        {
            GameObject p2;
            p2 = Instantiate(tinta, tentacle2.position, tentacle2.rotation);        // els canons es diuen tentacles perquè la idea inicial era que disparés desde els tentacles
            p2.transform.Rotate(0, 0, -10);
        }
        else if (nombre_tintes > 4)
        {
            GameObject p3;
            p3 = Instantiate(tinta, tentacle3.position, tentacle3.rotation);
            p3.transform.Rotate(0, 0, 10);
        }
        else if (nombre_tintes > 3)
        {
            GameObject p4;
            p4 = Instantiate(tinta, tentacle4.position, tentacle4.rotation);
            p4.transform.Rotate(0, 0, 20);
        }
        else if (nombre_tintes > 2)
        {
            GameObject p5;
            p5 = Instantiate(tinta, tentacle5.position, tentacle5.rotation);
            p5.transform.Rotate(0, 0, -20);
        }
        else if (nombre_tintes > 1)
        {

            GameObject p6;
            p6 = Instantiate(tinta, tentacle6.position, tentacle6.rotation);
            p6.transform.Rotate(0, 0, 30);
        }


        crono = Random.Range(cadenciaMin, cadenciaMax); // Següent tret
    }


    void FixedUpdate()
    {
        if (transform.position.x > 3)  //el boss es pararà quan arribi a x = 3
        {
            moviment.x = velX;
        }
        else
        {
            moviment.x = 0;
        }

        float amplitud = 5, freq = 2;   //Això fa que pugi i baixi
        
        moviment.y = Mathf.Sin(Time.time * freq) * amplitud;

        rb.velocity = moviment;
    }
    

    void Destruccio() // indica com es destrueix l'objecte
    {
        //Instantiate(explosio, transform.position, transform.rotation);
        isDestroyed = true;
        Destroy(gameObject);
    }
}
