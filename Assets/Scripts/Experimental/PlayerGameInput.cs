﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

#pragma warning disable 0649
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
            if (equippedGun != null)
            {
                // fire
                Vector3 raycastHit =
                    settings.RaycastFunctions.FromCameraToMouseRaycast(gameObject, equippedGun.WhatIsTarget,
                        out GameObject hit);


                equippedGun.Fire(raycastHit); // change to event
            }
        }

        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            // turn indicator on/off
            equippedGun.InvertIndicatorState();
        }
    }
}
#pragma warning restore 0649