using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SonZombie : MonoBehaviour {

    // Array avec les multiples son de zombies
    public AudioClip[] arrayAudioClip;
    private AudioSource son;
    private ActionZombie zombie;
    void Start()
    {
        son = GetComponent<AudioSource>();
        zombie = GetComponent<ActionZombie>();
        son.loop = false;

    }

    void Update()
    {
        // J'ai mis dans une array plusieurs son de zombies afin de pouvoir les alternés
        // car je trouvais que de mettre un son de zombie en loop etait trop répétitif
        if (!son.isPlaying && zombie.estVivant)
        {
            son.clip = arrayAudioClip[Random.Range(1, 5)];
            son.Play();
        }
    }
}
