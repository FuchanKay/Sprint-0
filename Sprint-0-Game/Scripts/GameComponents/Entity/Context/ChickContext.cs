namespace Scripts.GameComponents;
public class ChickContext(bool n, bool e, bool s, bool w) : IContext
{
    public bool N { get; set; } = n;
    public bool E { get; set; } = e;
    public bool S { get; set; } = s;
    public bool W { get; set; } = w;
}