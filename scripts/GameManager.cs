using Godot;


public partial class GameManager : Node
{
    private static readonly Logging.Logger logger = Logging.CreateLogger<GameManager>();

    public static GameManager Instance { get; private set; }

    public Node RootNode => GetTree().Root;

    public int carSpawned = 0;

    public GameManager()
    {
        if (Instance != null)
        {
            throw new System.Exception("Duplicate GameManager");
        }

        Instance = this;
    }

    public override void _Process(double delta)
    {
        if (carSpawned > 0)
            return;

        SpawnCar();
    }

    public void SpawnCar()
    {
        SceneManager.Instance.LoadScene("res://prefabs/CarBlack.tscn");
        carSpawned++;
    }

    public void FreeCar(Car car)
    {
        car.Position = car.startPosition;
    }
}