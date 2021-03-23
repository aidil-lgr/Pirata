using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrGavina : MonoBehaviour
{
    /// <summary>
    /// ----------------------------------------------------------------------------------
    /// DESCRIPCIÓ
    ///         Script utilitzat fer moure les gavines. 
    /// AUTOR:  Lídia García Romero
    /// DATA:   03/08/21
    /// VERSIÓ: 1.0
    /// CONTROL DE VERSIONS
    ///         1.0: Les gavines es mouen correctament. Acabat.
    /// ----------------------------------------------------------------------------------
    /// </summary>

    float velocitatX, velocitatY;

    void Start()
    {
        velocitatX = Random.Range(-3, -1);

        if(transform.position.y < 0) //Fer que la gavina vagi volant cap adalt o abaix en funció de l'altura a la que es trobi inicialment. 
        {
            velocitatY = Random.Range(5, 1);
        }
        else
        {
            velocitatY = Random.Range(-5, -1);
        }
    }

    void Update()
    {
        transform.Translate(velocitatX * Time.deltaTime, velocitatY * Time.deltaTime, 0);
    }
}
