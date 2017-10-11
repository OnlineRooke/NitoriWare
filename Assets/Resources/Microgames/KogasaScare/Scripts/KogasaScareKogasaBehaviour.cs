﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KogasaScareKogasaBehaviour : MonoBehaviour
{

    public Animator kogasaAnimator;
    public bool iswalking = false;
    public string kogasawalkanim;
    public string kogasawalkanimreverse;
    public Transform kogasaTransform;
    public Sprite stillSprite;
    public float moveSpeed;
    public float maxposXleft;
    public float maxposXright;

    private SpriteRenderer spriteRenderer;
    private int direction;

    // Use this for initialization
    void Start()
    {
        kogasaAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //maxposXleft = -5.214749; //set in inspector
        //maxposXright = 6.21187;  //set in inspector
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            //TODO scare
        }

        if (spriteRenderer.sprite == stillSprite)
        {
            //if (direction == -1 && Input.GetKey(KeyCode.LeftArrow))
            //    direction = -1;
            //else if (direction == 1 && Input.GetKey(KeyCode.RightArrow))
            //    direction = 1;
            //else
                direction = Input.GetKey(KeyCode.LeftArrow) ? -1 : (Input.GetKey(KeyCode.RightArrow) ? 1 : 0);

        }
        else if (!(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow)))
        {
            if (direction == -1 && Input.GetKey(KeyCode.RightArrow))
                direction = 1;
            else if (direction == 1 && Input.GetKey(KeyCode.LeftArrow))
                direction = -1;
        }

        transform.position += Vector3.right * (float)direction * moveSpeed * Time.deltaTime;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, maxposXleft, maxposXright), transform.position.y, transform.position.z);

        kogasaAnimator.SetInteger("direction", direction);
        

        //if (Input.GetKey("left") && !Input.GetKey("right"))
        //{
        //    if (kogasaTransform.position.x >= maxposXleft)
        //    {
        //        kogasaAnimator.Play(kogasawalkanim);
        //        //kogasaAnimator.SetFloat("Direction", 1.0f);
        //        if (isOnMovementSprite())
        //        {
        //            kogasaTransform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        //        }
        //    }
        //}
        //if (Input.GetKeyUp("left"))
        //{
        //    kogasaAnimator.Play("idle");
        //}
        //if (Input.GetKey("right") && !Input.GetKey("left"))
        //{
        //    if (kogasaTransform.position.x <= maxposXright)
        //    {
        //        kogasaAnimator.Play(kogasawalkanimreverse);

        //        //kogasaAnimator.SetFloat("Direction", -1.0f); //for some reason, there's a weird stutter at the start of the animation. i'm going with two animations instead
        //        if (isOnMovementSprite())
        //            kogasaTransform.Translate(Vector2.left * -moveSpeed * Time.deltaTime);
        //    }
        //}
        //if (Input.GetKeyUp("right"))
        //{
        //    kogasaAnimator.Play("idle");
        //}

        //if (Input.GetKey("left") && Input.GetKey("right"))
        //{
        //    kogasaAnimator.Play("idle");
        //}
    }

    //bool isOnMovementSprite()
    //{
    //    foreach (Sprite sprite in kogasaMovementSprites)
    //    {
    //        if (spriteRenderer.sprite == sprite)
    //            return true;
    //    }
    //    return false;
    //}
}
