using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("the player to follow")]
    private Transform m_PlayerTransform;

    [SerializeField]
    [Tooltip("the offset from the player's origin to the camera")]
    private Vector3 m_Offset;

    [SerializeField]
    [Tooltip("how fast the player can rotate the camera to the left and right")]
    private float m_RotationSpeed = 10;

    #endregion

    #region Main Updates
    private void LateUpdate()
    {
        Vector3 newPos = m_PlayerTransform.position + m_Offset;

        transform.position = Vector3.Slerp(transform.position, newPos, 1);

        float rotationxAmount = m_RotationSpeed * Input.GetAxis("Mouse X");
        float rotationyAmount = m_RotationSpeed * Input.GetAxis("Mouse Y");

        transform.RotateAround(m_PlayerTransform.position, Vector3.up, rotationxAmount + rotationyAmount);

        m_Offset = transform.position - m_PlayerTransform.position;
    } 


    #endregion
}
