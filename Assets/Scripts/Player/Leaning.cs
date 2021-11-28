using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

//Tutorial: https://www.youtube.com/watch?v=7ydsg_zJ0IY&=7&t=0s

public class Leaning : MonoBehaviour
{
    #region Controls
    public KeyCode leanLeftKey = KeyCode.Q;
    public KeyCode leanRightKey = KeyCode.E;
    #endregion

    [SerializeField]private float m_Amount = 10f;

    private FirstPersonController m_FPSController;

    private Transform m_CameraTransform;

    private Vector3 m_Initpos;

    private Quaternion m_InitRot;

    private bool m_IsLeaningLeft = false;
    private bool m_IsLeaningRight = false;

    public void Start()
    {
        m_FPSController = GetComponent<FirstPersonController>();
        m_CameraTransform = m_FPSController.transform.transform.GetChild(0);

        m_Initpos = m_CameraTransform.localPosition;
        m_InitRot = m_CameraTransform.localRotation;
    }

    private void Update()
    {
        if (Input.GetKey(leanLeftKey))
        {
            Debug.Log("You're leaning left");
            m_IsLeaningLeft = true;
        }
        else
        {
            Debug.Log("You're not leaning left any more");
            m_IsLeaningLeft = false;
        }

        if (Input.GetKey(leanRightKey))
        {
            Debug.Log("You're leaning right");
            m_IsLeaningRight = true;
        }
        else
        {
            Debug.Log("You're not leaning tight any more");
            m_IsLeaningRight = false;
        }

        CheckLeaning();
    }

    void CheckLeaning()
    {
        if (m_IsLeaningLeft)
        {
            m_FPSController.SetRotateZ(m_Amount);
        }
        else if (m_IsLeaningRight)
        {
            m_FPSController.SetRotateZ(-m_Amount);
        }
        else
        {
            m_FPSController.SetRotateZ(m_InitRot.eulerAngles.z);
        }

    }
}
