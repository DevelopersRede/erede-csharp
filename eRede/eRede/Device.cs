namespace eRede;

public class Device
{
    public int ColorDepth { get; set; }
    public string DeviceType3ds { get; set; }
    public bool JavaEnabled { get; set; }
    public string Language { get; set; } = "BR";
    public int ScreenHeight { get; set; }
    public int ScreenWidth { get; set; }
    public int TimeZoneOffset { get; set; } = 3;
}