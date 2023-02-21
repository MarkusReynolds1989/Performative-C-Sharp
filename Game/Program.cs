using Raylib_cs;

namespace Game;

internal static class Program
{
    struct Enemy
    {
        public int X;
        public int Y;
        public int Size;
        public Color Color;
        public bool AliveFlag;
        public bool IsActive;
    }

    ref struct Player
    {
        public int X;
        public int Y;
        public int Size;
        public Color Color;

        public Player(int x, int y, int size, Color color)
        {
            X = x;
            Y = y;
            Size = size;
            Color = color;
        }
    }

    public static void Main()
    {
    init:
        var player = new Player(200, 200, 20, Color.BLUE);
        Span<Enemy> enemies = stackalloc Enemy[100];

        Raylib.InitWindow(400, 400, "Example");

    window_open:
        if (Raylib.WindowShouldClose())
        {
            goto close_window;
        }

    drawing:
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.BLACK);
        Raylib.EndDrawing();
        goto window_open;

    update:

    close_window:
        Raylib.CloseWindow();
    }
}