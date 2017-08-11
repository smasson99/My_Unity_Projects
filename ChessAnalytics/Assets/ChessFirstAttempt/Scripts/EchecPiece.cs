using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Scripts/Interface/PieceScript")]
public class EchecPiece : MonoBehaviour
{
    public bool isDead = false;
    
    public bool estBlanc = true;

    public enum Type
    {
        PION_BLANC = 1,
        TOUR_BLANCHE = 2,
        CAVALIER_BLANC = 3,
        FOU_BLANC = 4,
        REINE_BLANCHE = 5,
        ROI_BLANC = 6,

        PION_NOIR = -1,
        TOUR_NOIRE = -2,
        CAVALIER_NOIR = -3,
        FOU_NOIR = -4,
        REINE_NOIRE = -5,
        ROI_NOIR = -6,
    }

    //Sprinte tableau... A COMPLETER
    //ACTION 1... A COMPLTETE
    //ACTION 2... A COMPLTETE
    public Type typeCourant = Type.PION_BLANC;
    public EchecCase caseCourante;

    //Méthode publique SetType ... A COMPLETER

    public void StartAtCase(EchecCase caseDepart)
    {
        isDead = false;

        caseCourante = caseDepart;

        transform.position = new Vector3(caseDepart.transform.position.x, caseDepart.transform.position.y, 0);
    }

    public void MoveToCase(EchecCase caseCible)
    {
        caseCourante = caseCible;

        transform.position = new Vector3(caseCible.transform.position.x, caseCible.transform.position.y, 0);
    }
}
