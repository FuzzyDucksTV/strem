﻿using System.Reactive.Disposables;
using System.Reactive.Linq;
using Strem.Core.Events;
using Strem.Core.Events.Bus;
using Strem.Core.Extensions;
using Strem.Core.Plugins;
using Strem.Core.State;
using Strem.Twitch.Events;
using Strem.Twitch.Events.OAuth;
using Strem.Twitch.Extensions;
using Strem.Twitch.Services.OAuth;
using Strem.Twitch.Variables;
using TwitchLib.Api.Interfaces;

namespace Strem.Twitch.Plugin;

public class TwitchPluginStartup : IPluginStartup, IDisposable
{
    private CompositeDisposable _subs = new();
    
    public ITwitchOAuthClient TwitchOAuthClient { get; }
    public ITwitchAPI TwitchApi { get; }
    public IEventBus EventBus { get; }
    public IAppState AppState { get; }
    public ILogger<TwitchPluginStartup> Logger { get; }

    public TwitchPluginStartup(ITwitchOAuthClient twitchOAuthClient, IEventBus eventBus, IAppState appState, ITwitchAPI twitchApi, ILogger<TwitchPluginStartup> logger)
    {
        TwitchOAuthClient = twitchOAuthClient;
        EventBus = eventBus;
        AppState = appState;
        TwitchApi = twitchApi;
        Logger = logger;
    }

    public async Task StartPlugin()
    {
        Observable.Timer(TimeSpan.Zero, TimeSpan.FromMinutes(TwitchPluginSettings.RevalidatePeriodInMins))
            .Subscribe(x => VerifyToken())
            .AddTo(_subs);
        
        Observable.Timer(TimeSpan.Zero, TimeSpan.FromMinutes(TwitchPluginSettings.RefreshChannelPeriodInMins))
            .Subscribe(x => RefreshChannelDetails())
            .AddTo(_subs);
        
        EventBus.Receive<TwitchOAuthSuccessEvent>()
            .Subscribe(x => VerifyToken())
            .AddTo(_subs);
    }

    public async Task VerifyToken()
    {
        Logger.Information("Revalidating Twitch Access Token");
        
        if (AppState.HasTwitchOAuth())
        { await TwitchOAuthClient.ValidateToken(); }
    }

    public async Task RefreshChannelDetails()
    {
        Logger.Information("Refreshing Twitch Channel & Stream Information");
        
        if (!AppState.HasTwitchOAuth()) { return; }
        
        TwitchApi.Settings.SetCredentials(AppState);
        var userId = AppState.GetTwitchVar(TwitchVars.UserId);
        var accessToken = AppState.GetTwitchOAuthToken();
        
        var channelInformation = await TwitchApi.Helix.Channels.GetChannelInformationAsync(userId, accessToken);
        if (channelInformation != null && channelInformation.Data.Length > 0)
        {
            var channelData = channelInformation.Data[0];
            AppState.TransientVariables.Set(TwitchVars.Username, TwitchVars.TwitchContext, channelData.BroadcasterName);
            AppState.TransientVariables.Set(TwitchVars.ChannelTitle, TwitchVars.TwitchContext, channelData.Title);
            AppState.TransientVariables.Set(TwitchVars.ChannelGame, TwitchVars.TwitchContext, channelData.GameName);
        }

        var streamInformation = await TwitchApi.Helix.Streams.GetStreamsAsync(userIds: new List<string> { userId });
        if (streamInformation != null && streamInformation.Streams.Length > 0)
        {
            var streamData = streamInformation.Streams[0];
            AppState.TransientVariables.Set(TwitchVars.StreamViewers, TwitchVars.TwitchContext, streamData.ViewerCount.ToString());
            AppState.TransientVariables.Set(TwitchVars.StreamThumbnailUrl, TwitchVars.TwitchContext, streamData.ThumbnailUrl);
        }
    }

    public void Dispose()
    { _subs?.Dispose(); }
}