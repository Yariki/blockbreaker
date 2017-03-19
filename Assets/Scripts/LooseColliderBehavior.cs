using UnityEngine;
using System.Collections;

public class LooseColliderBehavior : MonoBehaviour
{

    private LevelManager LevelManager;


    void Start()
    {
        LevelManager = GameObject.FindObjectOfType<LevelManager>();
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        print("Trigger");
        LevelManager.LoadLevel("Loose Screen");
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");
    }

}
