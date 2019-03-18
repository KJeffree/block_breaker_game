using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;

    //cahced reference
    Level level;
    GameSession gameStatus;

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
