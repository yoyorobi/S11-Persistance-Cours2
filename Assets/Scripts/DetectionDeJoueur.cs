using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectionDeJoueur : MonoBehaviour
{
    public UnityEvent<GameObject> joueurDetecte;

    private void OnTriggerEnter2D(Collider2D autre)
    {
        if (autre.CompareTag("Joueur"))
        {
            joueurDetecte.Invoke(gameObject);
        }
    }
}
