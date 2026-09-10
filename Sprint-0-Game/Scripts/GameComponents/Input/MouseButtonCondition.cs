namespace Scripts.GameComponents.Input;

public class MouseButtonCondition(MouseButtons button)
{
    public MouseButtons Button { get; } = button;
    public bool Previous { get; set; } = false;
    public bool Current { get; set; } = false;
}