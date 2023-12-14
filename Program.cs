using System.Numerics;
using Raylib_cs;

Raylib.InitWindow(1920, 1080, "Escape the lava");
Raylib.SetTargetFPS(60);
Raylib.ToggleFullscreen();

Player player = new();
PlatformManager platformManager = new();
Lava lava = new();

player.platformManager = platformManager;
platformManager.player = player;

string currentScene = "menu";
int time = 0;

Camera2D camera;
camera.Offset = new Vector2(0, Raylib.GetScreenHeight() - 200);
camera.Rotation = 0f;
camera.Zoom = 1f;

while (!Raylib.WindowShouldClose())
{
    if (currentScene == "menu")
    {
        Raylib.ClearBackground(Color.BLACK);

        Raylib.DrawText("Weclome to ESCAPE THE LAVA", Raylib.GetScreenWidth() / 2 - 600, Raylib.GetScreenHeight() / 2 - 60, 80, Color.BEIGE);
        Raylib.DrawText("Press ENTER to play", Raylib.GetScreenWidth() / 2 - 220, Raylib.GetScreenHeight() / 2 + 200, 40, Color.BEIGE);

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
        {
            currentScene = "game";
        }

        Raylib.EndDrawing();
    }

    if (currentScene == "game")
    {
        time++;

        camera.Target = new Vector2(lava.lavaPos.X,lava.lavaPos.Y);

        Raylib.ClearBackground(Color.GRAY);

        Raylib.BeginMode2D(camera);

        player.Draw();
        player.Update();
        platformManager.Draw();
        platformManager.Update();
        lava.Draw();
        lava.Update();

        if (Raylib.CheckCollisionRecs(player.playerRec, lava.lavaRec))
        {
            currentScene = "lose";
        }

        Raylib.EndMode2D();

        Raylib.EndDrawing();
    }

    if (currentScene == "lose")
    {
        Raylib.ClearBackground(Color.BLACK);

        Raylib.DrawText("You lose", Raylib.GetScreenWidth() / 2 - 175, Raylib.GetScreenHeight() / 2 - 300, 80, Color.BEIGE);
        Raylib.DrawText($"Your time: {time / 60}s", Raylib.GetScreenWidth() / 2 - 120, Raylib.GetScreenHeight() / 2 - 100, 40, Color.BEIGE);
        Raylib.DrawText("Press R to play again", Raylib.GetScreenWidth() / 2 - 220, Raylib.GetScreenHeight() / 2, 40, Color.BEIGE);
        

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_R))
        {
            currentScene = "game";
            lava.lavaPos = new Vector2(0, Raylib.GetScreenHeight() - 200);
            player.playerPos = new Vector2(Raylib.GetScreenWidth() / 2 - player.playerRec.Width / 2, Raylib.GetScreenHeight() / 2 - player.playerRec.Height / 2);
            time = 0;
        }

        Raylib.EndDrawing();
    }
}