﻿using Strem.Flows.Data.Triggers;

namespace Strem.OBS.Flows.Triggers;

public class OnSceneChangedTriggerData : IFlowTriggerData
{
    public static readonly string TriggerCode = "on-obs-scene-changed";
    public static readonly string TriggerVersion = "1.0.0";

    public Guid Id { get; set; } = Guid.NewGuid();
    public string Code => TriggerCode;
    public string Version { get; set; } = TriggerVersion;

    public string MatchingSceneName { get; set; }
}