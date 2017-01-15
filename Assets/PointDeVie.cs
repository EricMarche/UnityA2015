using UnityEngine;
using System.Collections;

public class PointDeVie : MonoBehaviour {
    public bool estVivant;
    private int vie;
    private Animator _animator;
    private GameObject canvasGameOver;

    void Start()
    {
        estVivant = true;
        _animator = GetComponent<Animator>();
        vie = 5;
        canvasGameOver = GameObject.Find("GameOver");
        canvasGameOver.SetActive(false);
    }
    
    // Lorsque le joueur est blessé on soustrait le nombre de point de vie du joueur et 
    // on broadcast pour le canvas a l'écran. Si les points de vie sont inférieur a 0
    // le player est mort on change d'animation et on affiche le canvas gameover
    public void Blessé(int damage)
    {
        vie -= damage;
        
        if (vie <= 0)
        {
            _animator.SetBool("Mort", true);
            estVivant = false;
            canvasGameOver.SetActive(true);
        }

        Messenger<int>.Broadcast(GameEvent.JOUEUR_TOUCHER, vie);
    }

    // Sert lorsqu'on prend l'upgrade de point de vie nous rajoute un nombre de point de vie
    public void setVie(int p_vie)
    {
        vie += p_vie;
        Messenger<int>.Broadcast(GameEvent.JOUEUR_GUERIE, vie);
    }
}
