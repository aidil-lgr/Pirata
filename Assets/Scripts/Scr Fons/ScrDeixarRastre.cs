using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrDeixarRastre : MonoBehaviour
{
    /// <summary>
    /// ----------------------------------------------------------------------------------
    /// DESCRIPCIÓ
    ///         Script utilitzat per generar el rastre rere els vaixells
    /// AUTOR:  Lídia García Romero
    /// DATA:   23/03/2021
    /// VERSIÓ: 1.0
    /// CONTROL DE VERSIONS
    ///         1.0: Es generen correctament.
    /// ----------------------------------------------------------------------------------
    /// </summary>

    [SerializeField] Transform[] generadors;
    [SerializeField] GameObject escuma;

    void Update()
    {
        foreach (Transform generador in generadors)
        {
            Instantiate(escuma, generador.position, generador.rotation);
        }
    }
}
