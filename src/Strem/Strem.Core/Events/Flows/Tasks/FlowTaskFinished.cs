﻿namespace Strem.Core.Events.Flows;

public class FlowTaskFinished
{
    public Guid FlowId { get; }
    public Guid TaskId { get; }

    public FlowTaskFinished(Guid flowId, Guid taskId)
    {
        FlowId = flowId;
        TaskId = taskId;
    }
}