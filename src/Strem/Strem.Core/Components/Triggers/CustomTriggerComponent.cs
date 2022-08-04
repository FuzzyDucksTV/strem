﻿using Microsoft.AspNetCore.Components;
using Strem.Core.Flows.Triggers;

namespace Strem.Core.Components.Triggers;

public abstract class CustomTriggerComponent<T> : CustomFlowElementComponent
    where T : class, IFlowTriggerData
{
    [Parameter]
    public T Data { get; set; }
}