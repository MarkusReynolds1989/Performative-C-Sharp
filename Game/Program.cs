using System.Runtime.CompilerServices;
using Raylib_cs;
using Color = Raylib_cs.Color;

namespace Game;

internal static class Program
{
    public struct Entity
    {
        public int X;
        public int Y;
        public int Size;
        public Color Color;
        public bool AliveFlag;
        public bool ActiveFlag;

        public Entity(int x,
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

    private struct Enemy
    {
        public Entity Entity;

        public Enemy(Entity entity)
        {
            Entity = entity;
        }
    }

    public struct Bullet
    {
        public Entity Entity;

        public Bullet(Entity entity)
        {
            Entity = entity;
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
        enemies[i] = new Enemy(new Entity(x * size * 2, y, size, Color.RED, true, true));
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

    private static void InitBullets(ref Span<Bullet> bullets)
    {
        const int size = 5;

        for (int i = 0; i < bullets.Length; i += 1)
        {
            bullets[i].Entity = new Entity(-10, -10, size, Color.WHITE, true, true);
        }
    }

    private static void Main()
    {
    init:
        var player = new Player(200, 350, 20, Color.BLUE);
        Span<Enemy> enemies = stackalloc Enemy[84];
        Span<Bullet> bullets = stackalloc Bullet[30];

        GenerateEnemies(ref enemies);
        InitBullets(ref bullets);
        var lastActiveBullet = 0;

        Raylib.InitWindow(400, 400, "Example");
        Raylib.SetTargetFPS(60);

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
            if (enemy.Entity.AliveFlag)
            {
                Raylib.DrawRectangle(enemy.Entity.X, enemy.Entity.Y, enemy.Entity.Size, enemy.Entity.Size,
                                     enemy.Entity.Color);
            }
        }

        foreach (var bullet in bullets)
        {
            if (bullet.Entity.AliveFlag)
            {
                Raylib.DrawRectangle(bullet.Entity.X, bullet.Entity.Y, bullet.Entity.Size, bullet.Entity.Size,
                                     bullet.Entity.Color);
            }
        }

        Raylib.EndDrawing();


    update:
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
        {
            if (lastActiveBullet < bullets.Length - 1)
            {
                lastActiveBullet += 1;
            }
            else
            {
                lastActiveBullet = 0;
            }

            bullets[lastActiveBullet].Entity.X = player.X;
            bullets[lastActiveBullet].Entity.Y = player.Y - player.Size;
        }

        if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
        {
            player.X += 1;
        }

        if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
        {
            player.X -= 1;
        }

        for (var i = 0; i < bullets.Length; i += 1)
        {
            bullets[i].Entity.Y -= 1;
        }

        bool Contains(Entity one, Entity two)
        {
            return !(two.X < one.X || two.Y < one.Y || two.X + two.Size > one.X + one.Size || two.Y +
                two.Size > one.X + one.Size);
        }

        for (var i = 0; i < enemies.Length; i += 1)
        {
            for (var y = 0; y < bullets.Length; y += 1)
            {
                if (Contains(enemies[i].Entity, bullets[y].Entity))
                {
                    bullets[y].Entity.Y = -10;
                    enemies[i].Entity.Y = -20;
                }
            }
        }

        goto window_open;

    close_window:
        Raylib.CloseWindow();
    }
}