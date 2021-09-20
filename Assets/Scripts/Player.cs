using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLibs.MemorySystem;

public class Player : MonoBehaviour
{
    GameControls gameControls;
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
        gameControls = new GameControls();
        anim = GetComponent<Animator>();
    }

    void OnEnable()
    {
        gameControls.Enable();
    }

    void OnDisable()
    {
        gameControls.Disable();
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
        /*MemorySystem.NewGame("game1");
        Gamemanager.instance.CurrentGameData = MemorySystem.LoadGame("game1");
        CheckData();
        Gamemanager.instance.CurrentGameData.PlayerLevel = 100;
        MemorySystem.SaveGame(Gamemanager.instance.CurrentGameData);
        CheckData();*/
        gameControls.Gameplay.Jump.performed += _=> Jump();
    }

    void FixedUpdate()
    {
        rb2D.position += Axis * moveSpeed * Time.deltaTime;
        //Debug.Log("Fixed Update");
    }

    void Update()
    {
        spr.flipX = FlipSpriteX;
        //transform.Translate(Axis * 5f * Time.deltaTime);
        //Hello();
        //Debug.Log("Update");
    }

    void LateUpdate()
    {
        anim.SetFloat("axisX", Mathf.Abs(Axis.x));
        //Debug.Log("Late Update");
    }

    void Jump()
    {
        if(IsGrounding)
        {
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    //void Hello() => Debug.Log("Hello");

    //Vector2 Axis => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    Vector2 Axis => gameControls.Gameplay.Axis.ReadValue<Vector2>();

    bool FlipSpriteX => Axis.x > 0 ? false : Axis.x < 0 ? true : spr.flipX;

    bool IsGrounding => rb2D.IsTouching(groundFilter);
}
