using UnityEngine;

[AddComponentMenu("Scripts/Interface/UpdateHealthBar")]
public class UpdateHealthBar : MonoBehaviour
{
    #region:values
    #endregion

    #region:basicFunctions
    #endregion

    #region:functionalities
    public void UpdateVisual(float currentHealth, float maxHealth)
    {
        transform.localScale = new Vector3((currentHealth/maxHealth), transform.localScale.y, transform.localScale.z);
    }
    #endregion
}
