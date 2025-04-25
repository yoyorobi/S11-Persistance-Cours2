using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoreV2 : MonoBehaviour
{
    [SerializeField] private float vitesse;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Random.insideUnitCircle * vitesse;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Joueur"))
        {
            if(JeuEspaceV2.instance != null)
            {
                JeuEspaceV2.instance.DetruireJoueur(collision.gameObject);
            }
            Destroy(collision.gameObject);
        }
    }
}
