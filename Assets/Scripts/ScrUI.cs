using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrUI : MonoBehaviour
{
    /// <summary>
    /// ----------------------------------------------------------------------------------
    /// DESCRIPCIÓ
    ///         Script utilitzat per gestionar la UI
    /// AUTOR:  Francesc Alamán
    /// DATA:   19/03/2021
    /// VERSIÓ: 1.0
    /// CONTROL DE VERSIONS
    ///         1.0: Controla si els elements es mostren correctament per pantalla.
    ///         2.0: Controla si els elements mostren correctament les dades. (falten dades ScrControlGame)
    ///         3.0: Lidia: solucionar errors i netejar codi.
    /// ----------------------------------------------------------------------------------
    /// </summary>
    /// 

    [SerializeField] Text monedesT, vidaT, municioT; //Per accedir a puntuació, vida restant, pickups, bales i temps
    public GameObject control;

    void Update()
    {
        monedesT.text = control.GetComponent<ScrControlGame>().monedes.ToString();
        municioT.text = control.GetComponent<ScrControlGame>().municio.ToString();
        vidaT.text = control.GetComponent<ScrControlGame>().vida.ToString();
    }
}
