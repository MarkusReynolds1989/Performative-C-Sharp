using System.Runtime.CompilerServices;
using Raylib_cs;
using Color = Raylib_cs.Color;

namespace Game;

internal static class Program
{
    private struct Enemy
    {
        public int X;
        public int Y;
        public int Size;
        public Color Color;
        public bool AliveFlag;
        public bool ActiveFlag;

        public Enemy(int x,
                     int y,
                     int size,
                     Color color,
                     bool aliveFlag,
                     bool activeFlag)
        {
            X = x;
            Y = y;
            Size = size;
            Color = color;
            AliveFlag = aliveFlag;
            ActiveFlag = activeFlag;
        }
    }

    private ref struct Player
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

    // Inline this so it actually just copies to the caller site.
    // No new stack frame generated.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void GenerateEnemies(ref Span<Enemy> enemies)
    {
        const int size = 15;
        var i = 0;
        var x = 1;
        var y = 10;

    load_enemy:
        enemies[i] = new Enemy(x * size * 2, y, size, Color.RED, true, true);
        x += 1;

        if (x * size * 2 > 385)
        {
            y += size * 2;
            x = 1;
        }

        i += 1;
        if (i < enemies.Length)
        {
            goto load_enemy;
        }
    }

    private static void Main()
    {
    init:
        var player = new Player(200, 350, 20, Color.BLUE);
        Span<Enemy> enemies = stackalloc Enemy[84];
        GenerateEnemies(ref enemies);

        Raylib.InitWindow(400, 400, "Example");

    window_open:
        if (Raylib.WindowShouldClose())
        {
            goto close_window;
        }

    drawing:
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.BLACK);
        Raylib.DrawRectangle(player.X, player.Y, player.Size, player.Size, player.Color);
        foreach (var enemy in enemies)
        {
            if (enemy.AliveFlag)
            {
                Raylib.DrawRectangle(enemy.X, enemy.Y, enemy.Size, enemy.Size, enemy.Color);
            }
        }

        Raylib.EndDrawing();
        goto window_open;

    update:

    close_window:
        Raylib.CloseWindow();
    }
}