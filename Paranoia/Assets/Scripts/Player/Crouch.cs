using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tutorial Source https://www.youtube.com/watch?v=mYeyMn-2HkA&

public class Crouch : MonoBehaviour
{
    public CharacterController m_CharcterController;

    private bool m_Crouch = false;

    private float m_OriginalHeight;

    [SerializeField] private float m_CrouchHeight = 0.5f;


    public KeyCode crouchKey = KeyCode.LeftControl;

    private void Start()
    {
        m_CharcterController = GetComponent<CharacterController>();
        m_OriginalHeight = m_CharcterController.height;
    }

    void Update()
    {
        if (Input.GetKeyDown(crouchKey))
        {
            m_Crouch = !m_Crouch;

            CheckCrouch();
            print("You're Crouching.");
        }

    }

    void CheckCrouch()
    {
        if (m_Crouch == true)
        {
           m_CharcterController.height = m_CrouchHeight;
        }
        else
        {
           m_CharcterController.height = m_OriginalHeight;
        }
    }
}
