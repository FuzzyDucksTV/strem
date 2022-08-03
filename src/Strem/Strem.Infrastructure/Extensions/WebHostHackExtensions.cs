﻿using Microsoft.AspNetCore.Mvc;
using Strem.Core.Events;
using Strem.Core.Events.Bus;

namespace Strem.Infrastructure.Extensions;

// TODO: This will be removed once shared service collection stuff can be sorted
public static class WebHostHackExtensions
{
    public static IEventBus EventBus { get; set; }
    public static IServiceProvider ServiceLocator { get; set; }

    public static void PublishEvent<T>(this ControllerBase controller, T eventArgs) => EventBus.Publish(eventArgs);
    public static void PublishAsyncEvent<T>(this ControllerBase controller, T eventArgs) => EventBus.PublishAsync(eventArgs);
    public static T GetService<T>(this ControllerBase controller) => ServiceLocator.GetService<T>();
}