﻿using ParsecGaming;
using ParsecUnity;
using Rewired;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [HideInInspector] public int m_PlayerNumber;
    [HideInInspector] public GameObject m_Instance;
    [HideInInspector] public Parsec.ParsecGuest m_AssignedGuest;
    private PlayerMovement m_Movement;

    public void Setup(CustomController controller, CustomController keyboard, CustomController mouse)
    {
        ParsecInput.AssignGuestToPlayer(m_AssignedGuest, m_PlayerNumber);
        m_Movement = m_Instance.GetComponent<PlayerMovement>();
        if (m_Movement != null)
        {
            if (controller != null) ParsecRewiredInput.AssignCustomControllerToUser(m_AssignedGuest, controller);
            if (keyboard != null) ParsecRewiredInput.AssignKeyboardControllerToUser(m_AssignedGuest, keyboard);
            if (mouse != null) ParsecRewiredInput.AssignMouseControllerToUser(m_AssignedGuest, mouse);
            m_Movement.player = m_PlayerNumber;
            m_Movement.initReInput(controller, keyboard, mouse);
        }
    }

    public void BreakDown()
    {
        Destroy(m_Instance);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
