using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpItem : MonoBehaviour

{
    public float jumpMultiplier = 0.75f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.ActivateMassEffect(jumpMultiplier, 5f);
                Destroy(gameObject);
            }
        }
    }

}

