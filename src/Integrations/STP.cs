using Rage;

namespace WildernessCallouts.Integrations;

internal static class STP
{
    public static void SetDrunk(this Ped ped, bool isDrunk = true)
    {
        if (Settings.CheckExternals.STPinstalled)
            SetDrunk2(ped, isDrunk);
    }

    public static void SetDrunk2(this Ped ped, bool isDrunk = true)
    {
        StopThePed.API.Functions.setPedAlcoholOverLimit(ped, isDrunk);
    }

    public static void SetDrugged(this Ped ped, bool isDrugged = true)
    {
        if (Settings.CheckExternals.STPinstalled)
            SetDrugged2(ped, isDrugged);
    }

    public static void SetDrugged2(this Ped ped, bool isDrugged = true)
    {
        StopThePed.API.Functions.setPedUnderDrugsInfluence(ped, isDrugged);
    }
}
