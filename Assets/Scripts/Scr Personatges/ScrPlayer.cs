using System.Collections;
using System.Collections.Generic;
using UnityEngine;




/// <summary>
/// ----------------------------------------------------------------------------------
/// DESCRIPCIÓ
///         Script utilitzat per controlar el player 
/// AUTOR:  Elisabet Arnal
/// DATA:   17/03/2021
/// VERSIÓ: 1.0
/// CONTROL DE VERSIONS
///         1.0: Moviment player i dispar(Aquest ultim no funciona)
///         2.0: Programació tripleshot. El dispar basic i el triple funcionen. 
/// ----------------------------------------------------------------------------------
/// </summary>


public class ScrPlayer : MonoBehaviour
  
{

    [SerializeField] float velocitat;
    
    

    Vector2 movi = new Vector2(); //Calcul moviment
    Rigidbody2D rb;               //Per accedir al riggidbody
    [SerializeField] AudioSource BasicShot;

    //**************Dispar*************
    [SerializeField] GameObject missil;
    [SerializeField] Transform[] canons;
    

    //*************Dispars Seguits**************

    [SerializeField] float cadencia = 0.5f; //Dispararà cada 5 dècimes de segón
    float crono = 0f;
    float cronoPowerUp = 0;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        BasicShot = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        movi.x = ETCInput.GetAxis("Horizontal") * velocitat;
        movi.y = ETCInput.GetAxis("Vertical") * velocitat;
        if (ETCInput.GetButton("Shoot") && crono > cadencia) Dispar();

        crono += Time.deltaTime;

        if (ETCInput.GetButtonUp("Shoot")) crono = cadencia; //parmet disparar ràpid amb diversos clics

        if (Input.GetKeyDown(KeyCode.T))  // Prototipus triple shoot
        {
            DisparTriple(true);
            cronoPowerUp = 5;
        }
        if (cronoPowerUp > 0) cronoPowerUp -= Time.deltaTime; else DisparTriple(false);

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

        BasicShot.Play();
        
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
