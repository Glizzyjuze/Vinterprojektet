using System.Numerics;
using Raylib_cs;

public class PlatformManager
{
    public Player player;

    public List<Rectangle> platforms = new List<Rectangle>();
    public int lastPlatform;

    float X1 = Raylib.GetScreenWidth() / 2 - 400;
    float X2 = 0;
    float X3 = Raylib.GetScreenWidth() - 400;

    public PlatformManager()
    {
        CreateInitialPlatforms();
    }

    public void CreateInitialPlatforms()
    {
        platforms.Add(new Rectangle(X1, 700, 800, 200));
        platforms.Add(new Rectangle(X2, 350, 400, 200));
        platforms.Add(new Rectangle(X3, 350, 400, 200));

        lastPlatform = 2;
    }

    public void Update()
    {
        float newY = platforms[lastPlatform].Y - 350;
        float newY2 = platforms[lastPlatform].Y;
        
        if (player.playerPos.Y > platforms[lastPlatform].Y && platforms[lastPlatform].X == X3)
        {
            platforms.Add(new Rectangle(X1, newY, 800, 200));
            lastPlatform += 1;
        }

        else if (player.playerPos.Y > platforms[lastPlatform].Y && platforms[lastPlatform].X == X1)
        {
            platforms.Add(new Rectangle(X2, newY, 400, 200));
            lastPlatform += 1;
        }

        else if (player.playerPos.Y > platforms[lastPlatform].Y && platforms[lastPlatform].X == X2)
        {
            platforms.Add(new Rectangle(X3, newY2, 400, 200));
            lastPlatform += 1;
        }

        for (int i = 0; i < platforms.Count; i++)
        {
            if (platforms[i].Y > Raylib.GetScreenHeight())
            {
                platforms.RemoveAt(i);
                lastPlatform--;
                i--;
            }
        }
    }

    public void Draw()
    {
        foreach (Rectangle platform in platforms)
        {
            Raylib.DrawRectangleRec(platform, Color.BLACK);
        }
    }
}
