﻿using System.Reactive.Linq;
using Microsoft.Extensions.Logging;
using Strem.Core.Events.Bus;
using Strem.Core.Extensions;
using Strem.Core.Flows.Processors;
using Strem.Core.Flows.Triggers;
using Strem.Core.State;
using Strem.Core.Variables;
using Strem.Flows.Default.Events;
using Strem.Flows.Default.Flows.Triggers.Data;

namespace Strem.Flows.Default.Flows.Triggers;

public class OnEventRaisedTrigger : FlowTrigger<OnEventRaisedTriggerData>
{
    public override string Code => OnEventRaisedTriggerData.TriggerCode;
    public override string Version => OnEventRaisedTriggerData.TriggerVersion;

    public override string Name => "On Event Raised";
    public override string Description => "Triggers when the matching event is raised";

    public OnEventRaisedTrigger(ILogger<IFlowTrigger> logger, IFlowStringProcessor flowStringProcessor, IAppState appState, IEventBus eventBus) 
        : base(logger, flowStringProcessor, appState, eventBus)
    {
    }

    public override IObservable<IVariables> Execute(OnEventRaisedTriggerData data)
    {
        return EventBus.Receive<UserDataEvent>()
            .Where(x => x.EventName == data.EventName)
            .Select(x =>
            {
                var newVariables = new Variables();
                newVariables.Set("event-data", x.Data);
                return newVariables;
            });
    }
}