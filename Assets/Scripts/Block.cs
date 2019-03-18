using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] int maxHits = 3;

    //cahced reference
    Level level;
    GameSession gameStatus;

    //state variables
    [SerializeField] int timesHit; //only serizlised for debug purposes


    private void Start()
    {
        CountBreakableBlocks();
        gameStatus = FindObjectOfType<GameSession>();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
   {
       if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
            TriggerSparklesVFX();
        }
    }

    private void DestroyBlock()
   {
       Destroy(gameObject);
       level.RemoveBlock();
       PlayBlockDestroySFX();
   }

   private void PlayBlockDestroySFX()
   {
       gameStatus.AddToScore();
       AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
   }

   private void TriggerSparklesVFX()
   {
       GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
       Destroy(sparkles, 2f);
   }

}
