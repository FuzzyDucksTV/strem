﻿using System.Reactive;
using Strem.Core.Variables;

namespace Strem.Core.Flows.Triggers;

public abstract class FlowTrigger<T> : IFlowTrigger 
    where T : IFlowTriggerData
{
    public abstract string Version { get; }
    public abstract string Code { get; }
    public abstract string Name { get; }
    public abstract string Description { get; }
    
    public abstract IObservable<IVariables> Execute(T data);

    public IObservable<IVariables> Execute(object data)
    {
        if(data is T typedData)
        { return Execute(typedData); }

        throw new ArgumentException($"Task type is {data.GetType()} not {typeof(T)}");
    }
}