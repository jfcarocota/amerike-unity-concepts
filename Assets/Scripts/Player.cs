using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLibs.MemorySystem;
using GameLibs.GameControlInputs;

public class Player : MonoBehaviour
{
    Rigidbody2D rb2D;
    SpriteRenderer spr;
    Animator anim;
    [SerializeField, Range(0.1f, 10f)]
    float jumpForce = 5f;
    [SerializeField, Range(0.1f, 10f)]
    float moveSpeed = 3f;
    [SerializeField]
    ContactFilter2D groundFilter;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        GameControlInputs.CreateGameControls();
    }

    void OnEnable()
    {
        GameControlInputs.EnableGameControls();
    }

    void OnDisable()
    {
        GameControlInputs.DisableGameControls();
    }

    void CheckData()
    {
        if(Gamemanager.instance.CurrentGameData != null)
        {
            Debug.Log($"GameName: {Gamemanager.instance.CurrentGameData.GameName}, PlayerLevel: {Gamemanager.instance.CurrentGameData.PlayerLevel}");
        }
        else
        {
            Debug.Log("The game not exist");
        }
    }

    void Start()
    {
        GameControlInputs.JumpEvent.performed += _=> Jump();
    }

    void FixedUpdate()
    {
        GameControlInputs.MovePlayer(ref rb2D, ref moveSpeed);
    }

    void Update()
    {
        spr.flipX = GameControlInputs.FlipSpriteX(ref spr);
    }

    void LateUpdate()
    {
        anim.SetFloat("axisX", Mathf.Abs(GameControlInputs.Axis.x));
        anim.SetBool("grounding", GameControlInputs.IsGrounding(ref rb2D, ref groundFilter));
        anim.SetFloat("velY", rb2D.velocity.y);
    }

    void Jump()
    {
        if(GameControlInputs.IsGrounding(ref rb2D, ref groundFilter))
        {
            GameControlInputs.Jump(ref rb2D, ref jumpForce);
            anim.SetTrigger("jump");
        }
    }
}
