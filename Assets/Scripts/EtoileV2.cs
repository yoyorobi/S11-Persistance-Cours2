using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtoileV2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D autre)
    {
        if (autre.CompareTag("Joueur"))
        {
            JeuEspaceV2.instance.CollecterEtoile();
            Destroy(gameObject);
        }
    }
}
