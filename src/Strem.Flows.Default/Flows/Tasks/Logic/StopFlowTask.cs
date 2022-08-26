﻿using Microsoft.Extensions.Logging;
using Strem.Core.Events.Bus;
using Strem.Core.Extensions;
using Strem.Core.Flows.Executors;
using Strem.Core.Flows.Processors;
using Strem.Core.Flows.Tasks;
using Strem.Core.State;
using Strem.Core.Variables;
using Strem.Flows.Default.Types;

namespace Strem.Flows.Default.Flows.Tasks.Logic;

public class StopFlowTask : FlowTask<StopFlowTaskData>
{
    public override string Code => StopFlowTaskData.TaskCode;
    public override string Version => StopFlowTaskData.TaskVersion;
    
    public override string Name => "Stop Flow";
    public override string Category => "Logic";
    public override string Description => "Stops the current flow and any optionally parent flows associated";
    
    public IFlowExecutor FlowExecutor { get; }

    public StopFlowTask(ILogger<FlowTask<StopFlowTaskData>> logger, IFlowStringProcessor flowStringProcessor, IAppState appState, IEventBus eventBus, IFlowExecutor flowExecutor) : base(logger, flowStringProcessor, appState, eventBus)
    {
        FlowExecutor = flowExecutor;
    }

    public override bool CanExecute() => true;
    
    public override async Task<ExecutionResult> Execute(StopFlowTaskData data, IVariables flowVars)
    { return data.StopParentFlowsToo ? ExecutionResult.CascadingFailure() : ExecutionResult.Failed(); }
}