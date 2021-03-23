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
    /// ----------------------------------------------------------------------------------
    /// </summary>
    /// 

    [SerializeField] Text monedes, vida, municio, temps; //Per accedir a puntuació, vida restant, pickups, bales i temps
    public static float crono = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        crono += Time.deltaTime;
        monedes.text = ScrControlGame.monedes;
        municio.text = ScrControlGame.municio;
        temps.text = "Temps: " + crono.ToString("0.0");
        vida.text = ScrControlGame.vida;
    }
}
