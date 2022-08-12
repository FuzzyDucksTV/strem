﻿using InputSimulatorStandard;
using Microsoft.Extensions.Logging;
using Strem.Core.Events.Bus;
using Strem.Core.Flows.Processors;
using Strem.Core.Flows.Tasks;
using Strem.Core.State;
using Strem.Core.Variables;

namespace Strem.Flows.Default.Flows.Tasks.Input;

public class SimulateKeyPressTask : FlowTask<SimulateKeyPressTaskData>
{
    public override string Code => SimulateKeyPressTaskData.TaskCode;
    public override string Version => SimulateKeyPressTaskData.TaskVersion;
    
    public override string Name => "Simulates Key Presses";
    public override string Category => "Input";
    public override string Description => "Simulates key presses on the system";

    public IInputSimulator InputSimulator { get; }

    public SimulateKeyPressTask(ILogger<FlowTask<SimulateKeyPressTaskData>> logger, IFlowStringProcessor flowStringProcessor, IAppState appState, IEventBus eventBus, IInputSimulator inputSimulator) : base(logger, flowStringProcessor, appState, eventBus)
    {
        InputSimulator = inputSimulator;
    }

    public override bool CanExecute() => OperatingSystem.IsWindows();
    
    public override async Task<bool> Execute(SimulateKeyPressTaskData data, IVariables flowVars)
    {
        if(data.KeysToPress.Count == 0 && data.KeyModifiers.Count == 0) { return true; }

        if (data.KeyModifiers.Count == 0)
        { InputSimulator.Keyboard.KeyPress(data.KeysToPress.ToArray()); }
        else
        { InputSimulator.Keyboard.ModifiedKeyStroke(data.KeyModifiers, data.KeysToPress); }

        return true;
    }
}