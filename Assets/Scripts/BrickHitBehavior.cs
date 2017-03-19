using UnityEngine;
using System.Collections;

public class BrickHitBehavior : MonoBehaviour
{
    public static int BreakablekCount = 0;

    public AudioClip Crack;
    public Sprite[] HitSprites;
    public GameObject smoke;
	
	private int timeHits;
    private LevelManager levelManager;
    

    private bool isBreakable;

	// Use this for initialization
	void Start ()
	{
        isBreakable = (this.tag == "Breakable");
	    if (isBreakable)
	    {
	        BreakablekCount++;
	    }
	    levelManager = GameObject.FindObjectOfType<LevelManager>();
	    timeHits = 0;
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
        AudioSource.PlayClipAtPoint(Crack,transform.position,0.001f);
	    if (isBreakable)
	    {
            HandlerHits();    
	    }
	}

    private void HandlerHits()
    {
        timeHits++;
        int maxHits = HitSprites.Length + 1;
        if (timeHits >= maxHits)
        {
            BreakablekCount--;
            levelManager.BrickDestoyed();
            
            GameObject smokePuff = Instantiate(smoke,gameObject.transform.position,Quaternion.identity) as GameObject;
            if(smokePuff != null)
			{
				smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
			}
            
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    private void LoadSprites()
    {
        var spriteIndex = timeHits - 1;
        var spriteRender = this.GetComponent<SpriteRenderer>();
        if (spriteRender != null  && HitSprites[spriteIndex] != null)
        {
            spriteRender.sprite = HitSprites[spriteIndex];
        }
        else
        {
        	Debug.Log("Sprite render wasn't found or Sprite is missing...");
        }
    }
}
