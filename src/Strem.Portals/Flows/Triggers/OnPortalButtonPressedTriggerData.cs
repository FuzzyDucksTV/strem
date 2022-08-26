﻿using Strem.Core.Flows.Triggers;

namespace Strem.Portals.Flows.Triggers;

public class OnPortalButtonPressedTriggerData : IFlowTriggerData
{
    public static readonly string TriggerCode = "on-portal-button-pressed";
    public static readonly string TriggerVersion = "1.0.0";

    public Guid Id { get; set; } = Guid.NewGuid();
    public string Code => TriggerCode;
    public string Version { get; set; } = TriggerVersion;
    
    public Guid RequiredPortalId { get; set; }
    public Guid RequiredButtonId { get; set; }
}