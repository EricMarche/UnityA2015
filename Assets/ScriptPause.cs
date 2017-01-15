using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScriptPause : MonoBehaviour {
    GameObject boutonHelp;
    GameObject boutonResume;
    GameObject panel;
    GameObject backgroundMusic;
    GameObject instruction;
    Text scoreText;
    Text pointVieText;

    [SerializeField] private Slider slider;

    AudioSource musiqueFond;
    // Use this for initialization
    int score = 0;

	void Start () {
        panel = GameObject.Find("Panel");
        boutonHelp = GameObject.Find("Help");
        boutonResume = GameObject.Find("Resume");
        backgroundMusic = GameObject.Find("BackgroundMusic");
        instruction = GameObject.Find("Instruction");
        scoreText = GameObject.Find("ScoreInt").GetComponent<Text>();
        pointVieText = GameObject.Find("HPInt").GetComponent<Text>();

        panel.SetActive(false);
        boutonHelp.SetActive(false);
        boutonResume.SetActive(false);
        instruction.SetActive(false);

        musiqueFond = GameObject.Find("Terrain").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        // Si le player appuie sur escape un menu pause apparait et le jeu arrete
        // si on rappuye sur escape alors que le canvas est afficher on remet les 
        // le jeu en marche
	    if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (panel.active == false)
            {
                panel.SetActive(true);
                boutonHelp.SetActive(true);
                boutonResume.SetActive(true);

                Time.timeScale = 0;
            }
            else
            {
                panel.SetActive(false);
                boutonHelp.SetActive(false);
                boutonResume.SetActive(false);

                Time.timeScale = 1f;
            }
        }
	}

    
    void Awake(){
        Messenger<int>.AddListener(GameEvent.ENNEMI_MORT, CompteurScore);
        Messenger<int>.AddListener(GameEvent.JOUEUR_TOUCHER, CompteurPV);
        Messenger<int>.AddListener(GameEvent.JOUEUR_GUERIE, CompteurPV);
    }

    void OnDestroy()
    {
        Messenger<int>.RemoveListener(GameEvent.ENNEMI_MORT, CompteurScore);
        Messenger<int>.RemoveListener(GameEvent.JOUEUR_TOUCHER, CompteurPV);
        Messenger<int>.RemoveListener(GameEvent.JOUEUR_GUERIE, CompteurPV);
    }

    // lié au bouton musique sur le canvas pause
    public void FermerMusique()
    {
        if (musiqueFond.isPlaying)
        {
            musiqueFond.Stop();
        }
        else
        {
            musiqueFond.Play();
        }
    }

    //Un slider nous permet de changer la difficulter
    public void ChangerDifficulter()
    {
        if (slider.value == 0)
        {
            Messenger<float>.Broadcast(GameEvent.DIFFICULTE_CHANGE, slider.value);
        }
        else if (slider.value == 1)
        {
            Messenger<float>.Broadcast(GameEvent.DIFFICULTE_CHANGE, slider.value);
        }
        else
        {
            Messenger<float>.Broadcast(GameEvent.DIFFICULTE_CHANGE, slider.value);
        }
    }


    public void OnBoutonResumeClick()
    {
        panel.SetActive(false);
        boutonHelp.SetActive(false);
        boutonResume.SetActive(false);

        Time.timeScale = 1f;
    }

    public void OnBoutonAideClick()
    {
        instruction.SetActive(true);
        panel.SetActive(false);
        boutonHelp.SetActive(false);
        boutonResume.SetActive(false);
    }

    public void OnClickBoutonFermerAide()
    {
        instruction.SetActive(false);
        panel.SetActive(true);
        boutonHelp.SetActive(true);
        boutonResume.SetActive(true);
    }

    // On incrémente les scores avec les valeurs recu du broadcast
    public void CompteurScore(int p_score)
    {
        score += p_score;
        scoreText.text = score.ToString();
    }

    public void CompteurPV(int pointVie)
    {
        pointVieText.text = pointVie.ToString();
    }
}