using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrDamage : MonoBehaviour
{
    /// <summary>
    /// ----------------------------------------------------------------------------------
    /// DESCRIPCIÓ
    ///         Script utilitzat per únicament determinar si l'objecte treu vida al player o 
    ///         als NPC. S'ha d'assignar a tots els prefabs que destrueixin objectes.
    /// AUTOR:  Lídia García Romero
    /// DATA:   15/03/2021
    /// VERSIÓ: 1.0
    /// CONTROL DE VERSIONS
    ///         1.0: Es crea y funciona correctament (test en els vaixells enemics)
    /// ----------------------------------------------------------------------------------
    /// </summary>

    public float damageNPC = 0f; //quantitat de mal que fa a un NPC
    public float damagePlayer = 0f; //quantitat de mal que fa al player
}
