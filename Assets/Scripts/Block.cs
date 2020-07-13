using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip blockSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    //cached reference
    Level level;
    GameSession gameStatus;

    [SerializeField] int timesHit; 

    private void Start()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameSession>();
        if( tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if( tag == "Breakable")
        {
            timesHit++;
            int maxHits = hitSprites.Length + 1;
            if(timesHit >= maxHits)
            {
                DestroyBlock();
            }
            else
            {
                ShowNextSprite();
            }
        }
    }

    private void ShowNextSprite()
    {
        int spriteIndex = timesHit - 1;
        if(hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block Sprite is missing from the array " + gameObject.name );
        }
    }

    private void DestroyBlock()
    {
        gameStatus.UpdateScore();
        AudioSource.PlayClipAtPoint(blockSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggerSparklesVFX();
    }

    public void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
