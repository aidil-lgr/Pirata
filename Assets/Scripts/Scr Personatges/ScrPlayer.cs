using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ----------------------------------------------------------------------------------
/// DESCRIPCIÓ
///         Script utilitzat per controlar el player 
/// AUTOR:  Elisabet Arnal
/// DATA:   17/03/2021
/// VERSIÓ: 3.0
/// CONTROL DE VERSIONS
///         1.0: Moviment player i dispar(Aquest ultim no funciona)
///         2.0: Programació tripleshot. El dispar basic i el triple funcionen. 
///         3.0: Lidia: correcció del bug que no sonava l'audio clip de disparar. Neteja de codi.
/// ----------------------------------------------------------------------------------
/// </summary>


public class ScrPlayer : MonoBehaviour  
{
    [SerializeField] float velocitat;      
    Vector2 movi = new Vector2(); //Calcul moviment
    Rigidbody2D rb;

    //Per disparar_____________________________________________________________
    [SerializeField] GameObject missil;
    [SerializeField] Transform[] canons;
    [SerializeField] AudioClip BasicShot;

    [SerializeField] float cadencia = 0.5f; //Dispararà cada 5 dècimes de segon
    float crono = 0f;
    float cronoPowerUp = 0f;
    //_________________________________________________________________________

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Moviment amb joystic_____________________________________________________
        movi.x = ETCInput.GetAxis("Horizontal") * velocitat;
        movi.y = ETCInput.GetAxis("Vertical") * velocitat;
        //_________________________________________________________________________

        //Disparar_________________________________________________________________
        if (ETCInput.GetButton("Shoot") && crono > cadencia) Dispar(); //permet disparar amb cadència si el botó es queda clicat

        crono += Time.deltaTime;

        if (ETCInput.GetButtonUp("Shoot")) crono = cadencia; //parmet disparar ràpid amb diversos clics
        //_________________________________________________________________________

        //Triple Shot______________________________________________________________
        if (Input.GetKeyDown(KeyCode.T)) 
        {
            DisparTriple(true);
            cronoPowerUp = 5;
        }
        if (cronoPowerUp > 0) cronoPowerUp -= Time.deltaTime; else DisparTriple(false);
        //_________________________________________________________________________

    }

    void FixedUpdate()
    {
        rb.velocity = movi;
    }

    void Dispar()
    {
        foreach (Transform cano in canons)
            if (cano.gameObject.activeSelf)
            {
                Instantiate(missil, cano.position, cano.rotation);
            } 
        crono = 0;

        AudioSource.PlayClipAtPoint(BasicShot, Camera.main.transform.position);
    }

    void DisparTriple(bool estat)
    {
        canons[0].gameObject.SetActive(estat);
        canons[2].gameObject.SetActive(estat);
    }

    void Detruccio() 
    {
        Destroy(gameObject);
    }
}
