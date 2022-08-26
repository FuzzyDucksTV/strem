﻿using Strem.Core.Flows.Tasks;

namespace Strem.OBS.Flows.Tasks;

public class SetStreamStateTaskData : IFlowTaskData
{
    public static readonly string TaskCode = "set-obs-v4-stream-state";
    public static readonly string TaskVersion = "1.0.0";
    
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Code => TaskCode;
    public string Version { get; set; } = TaskVersion;
    
    public bool StartStream { get; set; }
}