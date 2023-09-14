using UnityEngine;

    public class BrickScript : MonoBehaviour {
        
    public int points;
    public int hitsToBreak;
    public Sprite newSprite;

    public void BreakBrick()
    {
        hitsToBreak--;
        GetComponent<SpriteRenderer>().sprite = newSprite;
    }

    }
