using UnityEngine;

/// <summary>
/// Pour éviter de ralentir le programme inutilement, je vais considérer que le GameDesigner a bien fait son travail et
/// que la sprite de la case existe.
/// 
/// Cette classe sert à appliquer l'action de changement de couleur des cases lorsque le joueur clique sur une pièce du
/// jeu.
/// </summary>
[AddComponentMenu("Scripts/Interface/CaseScript")]
public class EchecCase : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Color initialColor;

    /// <summary>
    /// Pour l'initialisation du programme.
    /// </summary>
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        initialColor = sprite.color;
    }

    /// <summary>
    /// Méthode dont le rôle est de seter la couleur selon celle entrée en paramètre.
    /// </summary>
    /// <param name="color">Couleur représentant la couleur à appliquer à la sprite 
    /// représentant la case</param>
    public void SetColor(Color color)
    {
        sprite.color = color;
    }

    /// <summary>
    /// Méthode dont le rôle est de reseter la couleur de la case (reseter à la
    /// couleur initiale).
    /// </summary>
    public void ResetColor()
    {
        sprite.color = initialColor;
    }
}
