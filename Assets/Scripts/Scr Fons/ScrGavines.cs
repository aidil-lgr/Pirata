using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrGavines : MonoBehaviour
{
    /// <summary>
    /// ----------------------------------------------------------------------------------
    /// DESCRIPCIÓ
    ///         Script utilitzat per crear un "generador" de gavines. 
    /// AUTOR:  Lídia García Romero
    /// DATA:   03/08/21
    /// VERSIÓ: 1.0
    /// CONTROL DE VERSIONS
    ///         1.0: Es generen correctament. Acabat.
    /// ----------------------------------------------------------------------------------
    /// </summary>


    float cadencia;
    [SerializeField] GameObject gavina;
 
    void Start()
    {
        cadencia = Random.Range(500, 2000);        
    }
   
    void Update()
    {
        cadencia -= 1;

        if (cadencia <= 0)
        {
            Instantiate(gavina, transform.position, transform.rotation);
            cadencia = Random.Range(1000, 7500);
        }
    }
}
