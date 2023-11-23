using System.Numerics;
using Raylib_cs;

public class Platform
{
    public Rectangle platform1;
    public Rectangle platform2;
    public Rectangle platform3;

    public void Draw()
    {
        platform1 = new Rectangle(Raylib.GetScreenWidth() / 2 - platform1.Width / 2, 700, 800, 200);
        platform2 = new Rectangle(0, 450, 400, 200);
        platform3 = new Rectangle(Raylib.GetScreenWidth() - platform3.Width, 450, 400, 200);

        Raylib.DrawRectangleRec(platform1, Color.BLACK);
        Raylib.DrawRectangleRec(platform2, Color.BLACK);
        Raylib.DrawRectangleRec(platform3, Color.BLACK);
    }
}
