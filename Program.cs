using Raylib_cs;

Raylib.InitWindow(1920, 1080, "window");
Raylib.SetTargetFPS(60);
Raylib.ToggleFullscreen();

Player player = new();
Platform platform = new();

while (!Raylib.WindowShouldClose())
{
    Raylib.ClearBackground(Color.GRAY);

    player.Draw();
    platform.Draw();

    Raylib.EndDrawing();
}