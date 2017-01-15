using UnityEngine;
using System.Collections;

public class ReactionZombie : MonoBehaviour {
    private static int vieMonstre;
    private Animator animateur;
    private int score;

    void Start()
    {
        animateur = GetComponent<Animator>();
        score = 0;
        vieMonstre = 5;
    }

    public void toucher()
    {
        ActionZombie zombie = GetComponent<ActionZombie>();
        if (zombie != null && vieMonstre <= 0)
        {
            zombie.EstVivant(false);
            StartCoroutine(Die());
        }
        vieMonstre--;
    }



    private IEnumerator Die()
    {
        animateur.SetBool("Mort", true);
        ++score;
        Messenger<int>.Broadcast(GameEvent.ENNEMI_MORT, score);

        yield return new WaitForSeconds(15.0f);

        Destroy(this.gameObject);
    }

    public void setVieMonstre()
    {
        vieMonstre = 0;
    }

}
