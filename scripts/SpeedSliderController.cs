using Godot;


public partial class SpeedSliderController : Control
{
    public HSlider slider;

    public Label label;

    public override void _Ready()
    {
        label = GDUtils.FindChild<Label>(this);
        label.Text = $"Speed: {Config.carSpeed} km/h";

        slider = GDUtils.FindChild<HSlider>(this);
        slider.MinValue = 0;
        slider.MaxValue = 1000;
        slider.Value = Config.carSpeed;
        slider.ValueChanged += OnSliderChanged;
    }

    private void OnSliderChanged(double Value)
    {
        Config.carSpeed = (float)Value;
        label.Text = $"Speed: {Config.carSpeed} km/h";
    }

}
