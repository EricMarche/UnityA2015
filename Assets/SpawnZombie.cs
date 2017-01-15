using UnityEngine;
using System.Collections;

public class SpawnZombie : MonoBehaviour {

    [SerializeField]
    private GameObject enemyPrefab;
    private GameObject _enemy;
    void Start()
    {

    }

    
    void Update()
    {
        // on spawn seulement un ennemi s'il n'y en a pas déja un
        if (_enemy == null)
        {
            // instancie le prefab qui sert d'ennemi et positionne a l'endroit du spawn
            _enemy = Instantiate(enemyPrefab) as GameObject;
            _enemy.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        }
    }

}
