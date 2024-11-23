using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using System;
using static PlayerList;
using Exiled.API.Enums;


namespace CustomPlugin
{
    public class Plugin : Plugin<Config>
    {
        public override string Prefix => "HTP";

        public override string Author => "pavlikHTP";

        public override string Name => "InfinityRadioBattery";

        public override Version Version => new Version(1, 0, 0);

        public override Version RequiredExiledVersion => new Version(8, 12, 0);

        public override PluginPriority Priority { get; } = PluginPriority.Default;

        public static Plugin Instance;

        public override void OnEnabled()
        {
            Instance = this;
            Exiled.Events.Handlers.Player.UsingRadioBattery += OnRadioUsingEv;

            Log.Debug("InfiniteRadioBattery has been enabled.");
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Instance = null;
            Exiled.Events.Handlers.Player.UsingRadioBattery -= OnRadioUsingEv;

            Log.Debug("InfiniteRadioBattery has been disabled.");
            base.OnDisabled();
        }

        public override void OnReloaded()
        {
            Exiled.Events.Handlers.Player.UsingRadioBattery -= OnRadioUsingEv;
            Exiled.Events.Handlers.Player.UsingRadioBattery += OnRadioUsingEv;
            base.OnReloaded();
        }

        private static void OnRadioUsingEv(UsingRadioBatteryEventArgs ev) => ev.IsAllowed = false;


    }
}
