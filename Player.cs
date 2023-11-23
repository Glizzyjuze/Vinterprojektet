using System.Numerics;
using Raylib_cs;

public class Player
{
    public Rectangle playerRec;
    public Vector2 playerPos;
    
    public float movementSpeed = 4.5f;
    public void Draw()
    {
        playerRec = new Rectangle(Raylib.GetScreenWidth() / 2 - playerRec.Width / 2, Raylib.GetScreenHeight() / 2 - playerRec.Height / 2, 70, 70);
        Raylib.DrawRectangleRec(playerRec, Color.BEIGE);
    }
}
