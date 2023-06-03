﻿using Strem.Flows.Data.Triggers;

namespace Strem.Flows.Default.Flows.Triggers.Input;

public class OnKeyboardShortcutTriggerData : IFlowTriggerData
{
    public static readonly string TriggerCode = "on-keyboard-shortcut";
    public static readonly string TriggerVersion = "1.0.0";
    
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Code => TriggerCode;
    public string Version { get; set; } = TriggerVersion;
}