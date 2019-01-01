using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    //config params
    [SerializeField] AudioClip destructionAud;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites;


    //cached reference
    Level level;
    GameSession game;

    //state variables
    //serialized for debug purposes
    [SerializeField] int timesHit;

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        game = FindObjectOfType<GameSession>();
        if (tag == "Breakable")
        {
            level.countBlocks();
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
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    private void DestroyBlock()
    {
        playBlockDestroy();
        Destroy(gameObject);
        level.blockDestroy();
        triggerSparklesVFX();
    }

    private void playBlockDestroy()
    {
        //Plays audio clip until the audio clip is finished
        //access cameras by Camera.__ where blank is the name of the camera
        AudioSource.PlayClipAtPoint(destructionAud, Camera.main.transform.position);
        game.addToScore();
    }

    private void triggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX,transform.position, transform.rotation);
        Destroy(sparkles, 2.0f);
    }
}
