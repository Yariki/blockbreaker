using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer instance = null;


    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            print("Music PLayer self-desctuctiung!");
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }


	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
