using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip blockSound;
    [SerializeField] GameObject blockSparklesVFX; 

    //cached reference
    Level level;
    GameSession gameStatus;

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
            gameStatus.UpdateScore();
            AudioSource.PlayClipAtPoint(blockSound, Camera.main.transform.position);
            Destroy(gameObject);
            level.BlockDestroyed();
            TriggerSparklesVFX();
        }
    }

    public void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
