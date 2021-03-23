using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrShot : MonoBehaviour
{
    /// <summary>
    /// ----------------------------------------------------------------------------------
    /// DESCRIPCIÓ
    ///         Script utilitzat per fer moure els trets (bombes, taques de tinta...)
    /// AUTOR:  Lídia García Romero
    /// DATA:   15/03/2021
    /// VERSIÓ: 2.0
    /// CONTROL DE VERSIONS
    ///         1.0: Funciona correctament (comprobat amb bombes dels enemics només)
    ///         2.0: Sempre funciona.Neteja de codi
    /// ----------------------------------------------------------------------------------
    /// </summary>

    [SerializeField] float velocitat = 20f;

    void Start()
    {
        Destroy(gameObject, 3); //després de 3 segons
    }

    void Update()
    {
        transform.Translate(velocitat * Time.deltaTime, 0, 0);
    }

    void Destruccio()
    {
        Destroy(gameObject);
    }
}
