﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    //cahced reference
    Level level;
    GameSession gameSession;

    //state variables
    [SerializeField] int timesHit; //only serizlised for debug purposes


    private void Start()
    {
        CountBreakableBlocks();
        gameSession = FindObjectOfType<GameSession>();
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
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        } 
        else 
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array" + gameObject.name);
        }
    }

    private void DestroyBlock()
   {
       Destroy(gameObject);
       level.RemoveBlock();
       PlayBlockDestroySFX();
       TriggerSparklesVFX();
   }

   private void PlayBlockDestroySFX()
   {
       gameSession.AddToScore();
       AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
   }

   private void TriggerSparklesVFX()
   {
       GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
       Destroy(sparkles, 2f);
   }

}
