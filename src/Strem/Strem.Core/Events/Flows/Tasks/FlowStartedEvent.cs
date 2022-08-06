﻿namespace Strem.Core.Events.Flows;

public class FlowTaskStarted
{
    public Guid FlowId { get; }
    public Guid TaskId { get; }

    public FlowTaskStarted(Guid flowId, Guid taskId)
    {
        FlowId = flowId;
        TaskId = taskId;
    }
}