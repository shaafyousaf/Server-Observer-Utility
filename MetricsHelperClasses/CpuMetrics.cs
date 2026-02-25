namespace MetricsHelperClasses;

public class CpuMetrics
{
    public double Total { get; set; }
    public double User { get; set; }
    public double System { get; set; }
    public double Idle { get; set; }
    public int CpuCore { get; set; }
    public double CtxSwitchesRatePerSec { get; set; }
}
