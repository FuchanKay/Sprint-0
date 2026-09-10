namespace Scripts.GameComponents.Input;

public class ButtonCondition(MouseButtons button)
{
    public MouseButtons Button { get; } = button;
    public bool Previous { get; set; } = false;
    public bool Current { get; set; } = false;
}