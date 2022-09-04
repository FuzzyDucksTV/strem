﻿using Strem.Core.Flows.Triggers;

namespace Strem.Twitch.Flows.Triggers.Chat;

public class OnTwitchHostedTriggerData : IFlowTriggerData
{
    public static readonly string TriggerCode = "on-twitch-hosted";
    public static readonly string TriggerVersion = "1.0.0";

    public Guid Id { get; set; } = Guid.NewGuid();
    public string Code => TriggerCode;
    public string Version { get; set; } = TriggerVersion;

    public string RequiredChannel { get; set; }
}