using System.Numerics;
using Raylib_cs;

public class Player
{
    public PlatformManager platformManager;

    public Rectangle playerRec;
    public Vector2 playerPos;
    public Vector2 playerVel;

    public float gravity = 0.5f;

    public float moveSpeed = 10f;

    public float jumpForce = 20f;
    bool isJumping = false;

    public Player()
    {
        CreatePlayer();
    }

    public void CreatePlayer()
    {
        playerPos = new Vector2(Raylib.GetScreenWidth() / 2 - playerRec.Width / 2, 600);
        playerRec = new Rectangle(playerPos.X, playerPos.Y, 70, 70);
    }

    public void Draw()
    {
        Raylib.DrawRectangleRec(playerRec, Color.BEIGE);
    }

    public void Update()
    {
        playerVel.Y += gravity;

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE) && !isJumping)
        {
            playerVel.Y = -jumpForce;

            isJumping = true;
        }

        if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
        {
            playerPos.X += moveSpeed;
        }

        if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
        {
            playerPos.X -= moveSpeed;
        }

        playerPos += playerVel;
        playerRec.X = playerPos.X;
        playerRec.Y = playerPos.Y;

        foreach (Rectangle platform in platformManager.platforms)
        {
            if (Raylib.CheckCollisionRecs(playerRec, platform))
            {
                playerPos.Y = platform.Y - playerRec.Height;
                playerVel.Y = 0f;
                isJumping = false;
            }
        }
    }
}