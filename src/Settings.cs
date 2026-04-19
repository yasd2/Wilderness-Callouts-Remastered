namespace WildernessCallouts
{
    using Rage;
    using System;
    using System.IO;
    using System.Windows.Forms;

    internal static class Settings
    {
        // TODO: clean up ini file

        public static InitializationFile INIFile = new InitializationFile(@"Plugins\LSPDFR\Wilderness Callouts Config.ini");

        public static class General
        {
            public const string SECTION_NAME = "General";

            public static readonly string Name = Settings.INIFile.ReadString(SECTION_NAME, "Your Name", "Name"); 

#if DEBUG
            public const bool IsDebugBuild = true;
#else
            public const bool IsDebugBuild = false;
#endif

            //public static bool IsVetEnable = Settings.INIFile.ReadBoolean("General", "Is Vet Enable", true);  
            public static bool IsBinocularEnabled = INIFile.DoesKeyExist(SECTION_NAME, "Enable Binoculars") ?
                INIFile.ReadBoolean(SECTION_NAME, "Enable Binoculars", true) :
                INIFile.ReadBoolean(SECTION_NAME, "Are Binoculars Enable", true);
            //public static bool IsAirAmbulanceEnable = Settings.INIFile.ReadBoolean("General", "Is Air Ambulance Enable", true);  
        }


        public static class Callouts
        {
            public const string SECTION_NAME = "Callouts";

            public static readonly bool IsIllegalHuntingEnabled = Settings.INIFile.ReadBoolean(SECTION_NAME, "Enable Possible Illegal Hunting", true);
            public static readonly bool IsRocksBlockEnabled = Settings.INIFile.ReadBoolean(SECTION_NAME, "Enable Rocks Blocking the Road", true);
            public static readonly bool IsAircraftCrashEnabled = Settings.INIFile.ReadBoolean(SECTION_NAME, "Enable Aircraft Crash", true);
            public static readonly bool IsRecklessDriverEnabled = Settings.INIFile.ReadBoolean(SECTION_NAME, "Enable Reckless Driver", true);
            public static readonly bool IsWantedFelonEnabled = Settings.INIFile.ReadBoolean(SECTION_NAME, "Enable Wanted Felon In Vehicle", true);
            public static readonly bool IsSuicideAttemptEnabled = Settings.INIFile.ReadBoolean(SECTION_NAME, "Enable Suicide Attempt", true);
            public static readonly bool IsMissingPersonEnabled = Settings.INIFile.ReadBoolean(SECTION_NAME, "Enable Missing Person", true);
            public static readonly bool IsAnimalAttackEnabled = Settings.INIFile.ReadBoolean(SECTION_NAME, "Enable Animal Attack", true);
            public static readonly bool IsPublicDisturbanceEnabled = Settings.INIFile.ReadBoolean(SECTION_NAME, "Enable Public Disturbance", true);
            public static readonly bool IsHostageSituationEnabled = Settings.INIFile.ReadBoolean(SECTION_NAME, "Enable Hostage Situation", true);
            public static readonly bool IsArsonEnabled = Settings.INIFile.ReadBoolean(SECTION_NAME, "Enable Arson", true);
            public static readonly bool IsOfficerNeedsTransportEnabled = Settings.INIFile.ReadBoolean(SECTION_NAME, "Enable Officer Needs Transport", true);
            public static readonly bool IsAttackedPoliceStationEnabled = Settings.INIFile.ReadBoolean(SECTION_NAME, "Enable Attacked Police Station", true);
            public static readonly bool IsDemonstrationEnabled = Settings.INIFile.ReadBoolean(SECTION_NAME, "Enable Demonstration", true);
            //public static readonly bool IsEscortEnable = Settings.INIFile.ReadBoolean(SECTION_NAME, "Enable Escort", true); 
            public static readonly bool IsMurderInvestigationEnabled = Settings.INIFile.ReadBoolean(SECTION_NAME, "Enable Murder Investigation", true);
        }

        public static class AmbientEvents
        {
            public const string SECTION_NAME = "Ambient Events";

            public static readonly bool EnableAmbientEvents = Settings.INIFile.ReadBoolean(SECTION_NAME, "Enable Ambient Events", true);  
            public static readonly int MaxTimeAmbientEvent = Settings.INIFile.ReadInt32(SECTION_NAME, "Maximun Time Until Event", 360);  
            public static readonly int MinTimeAmbientEvent = Settings.INIFile.ReadInt32(SECTION_NAME, "Minimun Time Until Event", 50);  
            public static readonly bool ShowEventsBlips = Settings.INIFile.ReadBoolean(SECTION_NAME, "Show Blips", false);  
            //public static readonly bool IsHuntingAmbientEventEnable = Settings.INIFile.ReadBoolean(SECTION_NAME, "Enable Hunting Event", true);  
        }

        public static class ControlsKeys
        {
            public const string SECTION_NAME = "Keys";

            public static readonly Keys PrimaryActionKey = Settings.INIFile.ReadEnum<Keys>(SECTION_NAME, "Primary Action Key", Keys.Y);
            public static readonly Keys SecondaryActionKey = Settings.INIFile.ReadEnum<Keys>(SECTION_NAME, "Secondary Action Key", Keys.H);

            public static readonly Keys ForceCalloutEndKey = Settings.INIFile.ReadEnum<Keys>(SECTION_NAME, "End Callout Key", Keys.End);

            public static readonly Keys ModifierKey = Settings.INIFile.ReadEnum<Keys>(SECTION_NAME, "Modifier Key", Keys.LControlKey);

            public static readonly Keys ToggleBinocularsKey = Settings.INIFile.ReadEnum<Keys>(SECTION_NAME, "Toggle Binoculars", Keys.I);

            public static readonly Keys ToggleNightVisionKey = Settings.INIFile.ReadEnum<Keys>(SECTION_NAME, "Toggle Night Vision", Keys.NumPad9);
            public static readonly Keys ToggleThermalVisionKey = Settings.INIFile.ReadEnum<Keys>(SECTION_NAME, "Toggle Thermal Vision", Keys.NumPad3);
            public static readonly ControllerButtons ToggleNightVisionButton = Settings.INIFile.ReadEnum<ControllerButtons>(SECTION_NAME, "Toggle Night Vision Controller Button", ControllerButtons.B);
            public static readonly ControllerButtons ToggleThermalVisionButton = Settings.INIFile.ReadEnum<ControllerButtons>(SECTION_NAME, "Toggle Thermal Vision Controller Button", ControllerButtons.X);

            public static readonly Keys OpenInteractionMenuKey = Settings.INIFile.ReadEnum<Keys>(SECTION_NAME, "Open/Close Interaction Menu", Keys.O);

            public static readonly Keys ToggleHeliCameraKey = Settings.INIFile.ReadEnum<Keys>(SECTION_NAME, "Toggle Helicopter Camera", Keys.U);
            public static readonly Keys HeliCameraScanKey = Settings.INIFile.ReadEnum<Keys>(SECTION_NAME, "Helicopter Camera Scan", Keys.E);
            public static readonly ControllerButtons HeliCameraScanButton = Settings.INIFile.ReadEnum<ControllerButtons>(SECTION_NAME, "Helicopter Camera Scan Controller Button", ControllerButtons.Y);

            public static readonly Keys OpenCalloutsMenuKey = Settings.INIFile.ReadEnum<Keys>(SECTION_NAME, "Open/Close Callouts Menu", Keys.F8); // TODO: add OpenCalloutsMenuKey to ini
        }


        public static class Vet
        {
            public const string SECTION_NAME = "Vet";

            public static readonly string Name = Settings.INIFile.ReadString(SECTION_NAME, "Name", "Vet");
            public static readonly Model[] PedModels = Array.ConvertAll<string, Model>(Settings.INIFile.ReadString(SECTION_NAME, "Ped Models", "s_m_m_doctor_01,s_m_y_autopsy_01,s_m_m_paramedic_01,s_m_m_scientist_01,s_f_y_scrubs_01").Split(','), x => new Model(x));
            public static readonly Model VehModel = Settings.INIFile.ReadString(SECTION_NAME, "Vehicle Model", "dubsta3");
        }


        public static class AirAmbulance
        {
            public const string SECTION_NAME = "Air Ambulance";

            public static readonly string ParamedicName = Settings.INIFile.ReadString(SECTION_NAME, "Name", "Paramedic");


            public static readonly Model HeliModel = (INIFile.DoesKeyExist(SECTION_NAME, "Helicopter Model")) ?
                INIFile.ReadString(SECTION_NAME, "Helicopter Model", "polmav")
                : INIFile.ReadString(SECTION_NAME, "Helicoter Model", "polmav");


            public static readonly int HeliLiveryIndex = (INIFile.DoesKeyExist(SECTION_NAME, "Helicopter Livery Index")) ?
                INIFile.ReadInt32(SECTION_NAME, "Helicopter Livery Index", 0) :
                INIFile.ReadInt32(SECTION_NAME, "Helicoter Livery Index", 0);

            public static readonly Model[] PilotModels = Array.ConvertAll<string, Model>(Settings.INIFile.ReadString(SECTION_NAME, "Pilot Models", "s_m_m_pilot_02").Split(','), x => new Model(x));
            public static readonly Model[] ParamedicModels = Array.ConvertAll<string, Model>(Settings.INIFile.ReadString(SECTION_NAME, "Paramedic Models", "s_m_m_paramedic_01").Split(','), x => new Model(x));
        }

        public static bool CheckIniFile()
        {
            if (!Settings.INIFile.Exists() ||
                !Settings.INIFile.DoesSectionExist(Settings.AirAmbulance.SECTION_NAME) || 
                !Settings.INIFile.DoesSectionExist(Settings.AmbientEvents.SECTION_NAME) || 
                !Settings.INIFile.DoesSectionExist(Settings.Callouts.SECTION_NAME) ||
                !Settings.INIFile.DoesSectionExist(Settings.ControlsKeys.SECTION_NAME) ||
                !Settings.INIFile.DoesSectionExist(Settings.General.SECTION_NAME) ||
                !Settings.INIFile.DoesSectionExist(Settings.Vet.SECTION_NAME))
            {
                Settings.CreateIniFile();
                return true;
            }
            return true;
        }

        public static void CreateIniFile()
        {
            string path = @"plugins\LSPDFR\Wilderness Callouts Config.ini";
            InitializationFile ini = new InitializationFile(path);

            ini.ReCreate();

            string iniContent =
                @"//Wilderness Callouts by alexguirre


[General]

Your Name = Officer


// Set to false if you don't want that feature
Enable Binoculars = True



[Ambient Events]
// If false ambient events won't be created
Enable Ambient Events = True

// Maximum and minimum time between events in seconds
Maximun Time Until Event = 840
Minimun Time Until Event = 240

// If true, blips will be created for the events
Show Blips = True



[Callouts]

// Set to false if you don't want that callout
Enable Possible Illegal Hunting = True
Enable Rocks Blocking the Road = True
Enable Aircraft Crash = True
Enable Reckless Driver = True
Enable Wanted Felon In Vehicle = True
Enable Suicide Attempt = True
Enable Missing Person = True
Enable Animal Attack = True
Enable Public Disturbance = True
Enable Hostage Situation = True
Enable Arson = True
Enable Officer Needs Transport = True
Enable Attacked Police Station = True
Enable Demonstration = True


[Keys]
//** VALID KEYS: https://msdn.microsoft.com/en-us/library/system.windows.forms.keys(v=vs.110).aspx **\\
//** VALID CONTROLLER BUTTONS: If you have a valid link, pls send it to me **\\

Modifier Key = LControlKey

// Keys used in various callouts. Not Uses Modifier Key
Primary Action Key = Y
Secondary Action Key = H


// The key used to force the end of a callout. Not Uses Modifier Key
End Callout Key = End



//Uses Modifier Key
Open/Close Interaction Menu = O


// The binoculars movement with the mouse and the zoom with mouse wheel. Uses Modifier Key
Toggle Binoculars = I


// Uses Modifier Key
Toggle Helicopter Camera = U

// Not Uses Modifier Key
Helicopter Camera Scan = E
Helicopter Camera Scan Controller Button = Y


// Keys and controller buttons used for the binoculars and the helicopter camera. Not Uses Modifier Key
Toggle Night Vision = NumPad9
Toggle Thermal Vision = NumPad3
Toggle Night Vision Controller Button = B
Toggle Thermal Vision Controller Button = X





[Vet]
// The name that appears when the vet talk
Name = Vet

// Possible models for the vet, separate them with a comma("",""), without white spaces
Ped Models = s_m_m_doctor_01,s_m_y_autopsy_01,s_m_m_paramedic_01,s_m_m_scientist_01,s_f_y_scrubs_01

// Vet vehicle model
Vehicle Model = dubsta3


[Air Ambulance]
// The name that appears when the paramedic talk
Name = Paramedic

// The helicopter model, the peds must be able to rappel from it otherwise it will crash 
Helicopter Model = polmav

// The helicopter texture livery
Helicopter Livery Index = 1

// Possible models for the pilot, separate them with a comma("",""), without white spaces
Pilot Models = s_m_m_pilot_02
 
// Possible models for the paramedics, separate them with a comma("",""), without white spaces
Paramedic Models = s_m_m_paramedic_01
";

            File.WriteAllText(path, iniContent);
        }
    }
}
