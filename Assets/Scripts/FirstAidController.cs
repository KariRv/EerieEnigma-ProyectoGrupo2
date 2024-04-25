using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FirstAidController : MonoBehaviour
{
    public float healAmount = 25f; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealthController healthController = other.GetComponent<HealthController>();
            if (healthController != null)
            {
                healthController.Heal(healAmount);
            }
            Destroy(gameObject); 
        }
    }
}
