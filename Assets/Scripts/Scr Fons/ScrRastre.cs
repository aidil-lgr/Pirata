using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrRastre : MonoBehaviour
{
    /// <summary>
    /// ----------------------------------------------------------------------------------
    /// DESCRIPCIÓ
    ///         Script utilitzat per fer moure els rastres que el vaixell deixa al seu pas
    /// AUTOR:  Lídia García
    /// DATA:   23/03/2021
    /// VERSIÓ: 1.0
    /// CONTROL DE VERSIONS
    ///         1.0: Es generen correctament.
    /// ----------------------------------------------------------------------------------
    /// </summary>

    [SerializeField] float velocitat = -5f;
    void Start()
    {
        Destroy(gameObject, 3); //després d'1 segon
    }


    void Update()
    {
        float amplitud = 0.007f, freq = 5f;
        transform.Translate(velocitat * Time.deltaTime, amplitud * Mathf.Sin(freq * Time.time), 0); //moviment recte a l'eix X però ondulant al Y
    }
}
