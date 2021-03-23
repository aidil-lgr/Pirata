using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrNPCShot : MonoBehaviour
{
    /// <summary>
    /// ----------------------------------------------------------------------------------
    /// DESCRIPCIÓ
    ///         Script utilitzat per fer que els NPCs disparin només quan son visibles.
    /// AUTOR:  Lídia García Romero
    /// DATA:   15/03/2021
    /// VERSIÓ: 2.0
    /// CONTROL DE VERSIONS
    ///         1.0: Funciona correctament (però sense el sprite de la bomba corresponent, un provisional)
    ///         2.0: S'afegeix la bomba definitiva i l'audio. Neteja de codi
    /// ----------------------------------------------------------------------------------
    /// </summary>

    [SerializeField] Transform cano;
    [SerializeField] Transform bomba;
    [SerializeField] float cadenciaMin = 1, cadenciaMax = 3; 
    float temps;
    [SerializeField] Renderer render;

    [SerializeField] AudioClip shot;

    void Start()
    {
        temps = Random.Range(cadenciaMin, cadenciaMax); //Preparem primer tret
    }

    void Update()
    {
        if (render && ScrControlGame.EsVisibleDesde(render, Camera.main))
        {
            temps -= Time.deltaTime;

            if (temps <= 0)
            {
                Disparar();
            }
        }
    }
    void Disparar()
    {
        Transform b = Instantiate(bomba, cano.position, cano.rotation);
        AudioSource.PlayClipAtPoint(shot, Camera.main.transform.position);

        temps = Random.Range(cadenciaMin, cadenciaMax); //Preparem el següent shot
    }
}
