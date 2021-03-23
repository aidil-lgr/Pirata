using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrControlGame : MonoBehaviour
{

    /// <summary>
    /// ----------------------------------------------------------------------------------
    /// DESCRIPCIÓ
    ///         Script utilitzat per controlar coses extres del joc, com ara les tecles mágiques
    ///         o controlar si un objecte és visible per la càmera.
    /// AUTOR:  Lídia García Romero
    /// DATA:   15/03/2021
    /// VERSIÓ: 1.0
    /// CONTROL DE VERSIONS
    ///         1.0: Controla correctament si un objecte és visible per càmera.
    ///         2.0: 
    /// ----------------------------------------------------------------------------------
    /// </summary>

    public int monedes = 0;
    public int municio = 0;
    public int vida = 3;

    void Update()
    {
        
    }
    static public bool EsVisibleDesde(Renderer renderer, Camera camera) //per comprobar si un objecte es troba dins del camp de càmera o no
    {
        Plane[] plans = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(plans, renderer.bounds);
    }
}
