using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class JeuEspaceV2 : MonoBehaviour
{

    public int etoiles = 0;
    private int etoilesDebutNiveau;
    public TextMeshProUGUI textEtoiles;
    
    public GameObject fxExplosion;

    // Variable pour garder une référence à la copie global
    public static JeuEspaceV2 instance;

    // Avant de faire Start d'une nouvelle instance de notre script
    void Awake()
    {
        // Si on n'a pas encore une copie global prête
        if(instance == null)
        {
            // On va créer notre instance singleton
            // Garder la copie actuel comme global
            instance = this;
            // Marquer ce objet comme persistant
            DontDestroyOnLoad(gameObject);
        }
        // Si on a déjà un singleton prêt
        else
        {
            // On va détruire cette nouvelle copie extra
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        // Garder la valeur initiale des étoiles au début du niveau
        etoilesDebutNiveau = etoiles;
        textEtoiles.text = etoiles.ToString("0");
    }

    public void ChangerScene(int indexScene)
    {
        SceneManager.LoadScene(indexScene);
        // Après que la nouvelle scène est chargé,
        // on garde la valeur de étoiles au début
        etoilesDebutNiveau = etoiles;
    }

    public void CollecterEtoile()
    {
        // Sommer à la variable
        etoiles++;
        // Montrer à le Canvas
        textEtoiles.text = etoiles.ToString("0");
    }

    public void DetruireJoueur(GameObject joueur)
    {
        // Créer une copie du prefab d'explosion à la position du joueur
        Instantiate(fxExplosion, joueur.transform.position, joueur.transform.rotation);
        // Recommencer la scène après 3 s
        Invoke("RecommencerScene", 3f);
    }

    void RecommencerScene()
    {
        // Recharger la scène actuel
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // Retourner la valeur initiale des étoiles avant ce niveau
        etoiles = etoilesDebutNiveau;
        textEtoiles.text = etoiles.ToString("0");
    }
}
