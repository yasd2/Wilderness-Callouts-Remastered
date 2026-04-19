using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Rage;

namespace WildernessCallouts.Integrations;

internal static class STP
{
    public static void SetDrunk(this Ped ped, bool isDrunk = true)
    {
        if (Main.IsSTPInstalled)
            SetDrunk2(ped, isDrunk);
    }

    public static void SetDrunk2(this Ped ped, bool isDrunk = true)
    {
        StopThePed.API.Functions.setPedAlcoholOverLimit(ped, isDrunk);
    }

    public static void SetDrugged(this Ped ped, bool isDrugged = true)
    {
        if (Main.IsSTPInstalled)
            SetDrugged2(ped, isDrugged);
    }

    public static void SetDrugged2(this Ped ped, bool isDrugged = true)
    {
        StopThePed.API.Functions.setPedUnderDrugsInfluence(ped, isDrugged);
    }
}
