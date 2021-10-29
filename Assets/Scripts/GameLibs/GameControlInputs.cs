using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace GameLibs.GameControlInputs
{
    public static class GameControlInputs
    {
        static GameControls gameControls;

        public static void CreateGameControls() => gameControls = new GameControls();

        public static void EnableGameControls() => gameControls.Enable();
        public static void DisableGameControls() => gameControls.Disable();

        public static Vector2 Axis => gameControls.Gameplay.Axis.ReadValue<Vector2>();
        public static InputAction JumpEvent => gameControls.Gameplay.Jump;

        public static void MovePlayer(ref Rigidbody2D rb2D, ref float moveSpeed) => rb2D.position += GameControlInputs.Axis * moveSpeed * Time.deltaTime;
        public static void Jump(ref Rigidbody2D rb2D, ref float jumpForce) => rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        public static void FlipSprite(ref SpriteRenderer spriteRenderer) => spriteRenderer.flipX = FlipSpriteX(ref spriteRenderer);
        public static bool FlipSpriteX(ref SpriteRenderer spriteRenderer) => Axis.x > 0 ? false : Axis.x < 0 ? true : spriteRenderer.flipX;
        public static bool IsGrounding(ref Rigidbody2D rb2D, ref ContactFilter2D groundFilter) => rb2D.IsTouching(groundFilter);
    }
}