using System.Numerics;
using Raylib_cs;

public class Lava
{
    public Rectangle lavaRec;

    public Vector2 lavaPos;
    public float risingSpeed = 6f;

    public Lava()
    {
        CreateLava();
    }

    public void CreateLava()
    {
        lavaPos = new Vector2(0, Raylib.GetScreenHeight() - 200);
        lavaRec = new Rectangle(lavaPos.X, lavaPos.Y, Raylib.GetScreenWidth(), 200);
    }

    public void Draw()
    {
        Raylib.DrawRectangleRec(lavaRec, Color.RED);
    }
    
    public void Update()
    {
        lavaRec.X = lavaPos.X;
        lavaRec.Y = lavaPos.Y;

        lavaPos.Y -= risingSpeed;
    }
}
