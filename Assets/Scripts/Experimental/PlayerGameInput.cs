﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGameInput : MonoBehaviour // perhaps raycast here?
{
    [SerializeField] private GunBase equippedGun; // afterwards change to tool

    private GameSceneSettings settings;

    private void Start()
    {
        settings = GameSceneSettings.Instance;
    }
    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            // fire
            equippedGun.Fire(settings.RaycastFunctions.FullRaycast(gameObject, equippedGun.WhatIsTarget, out GameObject hit));
        }
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            // turn indicator on/off
            equippedGun.InvertIndicatorState();
        }
    }
    
   
}