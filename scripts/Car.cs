using Godot;


public partial class Car : Sprite2D
{
    private const float screenWidth = 1152;

    public Vector2 startPosition = new Vector2(-50, 300);

    private Vector2 textureSize;

    public override void _Ready()
    {
        textureSize = Texture.GetSize();
        Position = startPosition;
        Rotation = 3.14159f / 2;
    }

    public override void _Process(double delta)
    {
        Logging.Debug(Position);

        if (HasReachedEnd())
        {
            GameManager.Instance.FreeCar(this);
            return;
        }

        Position = new Vector2(
            Position.X + (float)delta * Config.carSpeed,
            Position.Y
        );
    }

    public bool HasReachedEnd()
    {
        return Position.X > (screenWidth + textureSize.X);
    }
}
