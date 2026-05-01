using WildernessCallouts.Integrations;

namespace WildernessCallouts
{
    using System;
    using System.Text;
    using System.Reflection;

    // RPH
    using Rage;

    // LSPDFR
    using LSPD_First_Response.Mod.API;

    // WildernessCallouts
    using WildernessCallouts.CalloutFunct;
    using WildernessCallouts.Menus;
    using WildernessCallouts.AmbientEvents;
    using System.IO;

    internal class Main : Plugin
    {

        /// <summary>
        /// Whether or not Police Smart Radio is running.
        /// </summary>
        public bool PoliceSmartRadioAvailable = false;

        /// <summary>
        /// Access to the Police Smart Radio functions singleton instance.
        /// </summary>
        public PoliceSmartRadioFunctions PoliceSmartRadioFunctions;

        public override void Initialize()
        {
            Logger.LogWelcome();

            MenuCommon.InitializeAllMenus();

            Functions.OnOnDutyStateChanged += Functions_OnOnDutyStateChanged;
            Game.FrameRender += Main.Process;

            Game.AddConsoleCommands();
        }

        public void Functions_OnOnDutyStateChanged(bool onDuty)
        {
            if (onDuty)
            {
                Common.RegisterCallouts();

                if (Settings.AmbientEvents.EnableAmbientEvents)
                    EventPool.EventsController();

                Globals.HeliCamera.StartManagerFiber().Start();

                // set up integration with PoliceSmartRadio
                if (IsLSPDFRPluginRunning("PoliceSmartRadio"))
                {
                    PoliceSmartRadioAvailable = true;
                    PoliceSmartRadioFunctions = new PoliceSmartRadioFunctions();
                }

                GameFiber.StartNew(delegate
                {
                    Logger.LogTrivial("Functions fiber started");

                    while (true)
                    {
                        GameFiber.Yield();

                        if (Settings.General.IsBinocularEnabled && Controls.ToggleBinoculars.IsJustPressed() &&
                            !Game.LocalPlayer.Character.IsInAnyVehicle(false) && !Binoculars.IsActive)
                        {
                            Binoculars.EnableBinoculars();
                        }

                        if (Controls.ToggleInteractionMenu.IsJustPressed() && !Binoculars.IsActive)
                        {
                            InteractionMenu.DisEnable();
                        }
                    }
                });

                Game.DisplayNotification("~g~<font size=\"14\"><b>WILDERNESS CALLOUTS</b></font>~s~~n~Version: ~b~" +
                                         WildernessCallouts.Common.GetVersion(
                                             @"Plugins\LSPDFR\Wilderness Callouts.dll") + "~s~~n~Loaded!");
            }
        }


        public override void Finally()
        {
            if (Globals.HeliCamera.ManagerFiber != null && Globals.HeliCamera.ManagerFiber.IsAlive) //
            {
                Globals.HeliCamera.ManagerFiber.Abort();
                Logger.LogTrivial("", "Aborted HeliCamera GF.");
            }
        }


        public static void Process(object sender, GraphicsEventArgs e)
        {
            MenuCommon.Pool.ProcessMenus();

            if (InteractionMenu.MainMenu.Visible)
            {
                foreach (Ped staticPeds in InteractionMenu.StaticPeds)
                {
                    if (staticPeds.Exists())
                    {
                        staticPeds.Tasks.AchieveHeading(staticPeds.GetHeadingTowards(Game.LocalPlayer.Character));
                    }
                }
            }
        }


        /// <summary>
        /// Determine if the given assembly name is running inside LSPDFR.
        /// </summary>
        /// <param name="Plugin"></param>
        /// <returns></returns>
        public static bool IsLSPDFRPluginRunning(string Plugin)
        {
            try
            {
                foreach (Assembly assembly in Functions.GetAllUserPlugins())
                {
                    if (string.Equals(assembly.GetName().Name, Plugin, StringComparison.CurrentCultureIgnoreCase))
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception e)
            {
                Game.LogTrivial($"{e}");
                return false;
            }
        }
    }
}