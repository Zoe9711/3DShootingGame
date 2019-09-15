using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("the amount of health that this grass restores")]
    private int m_HealthGain;
    public int HealthGain
    {
        get
        {
            return m_HealthGain;
        }
    }
    #endregion
}
