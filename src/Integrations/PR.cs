using LSPD_First_Response.Engine.Scripting.Entities;
using Rage;
using WildernessCallouts;

namespace WildernessCallouts.Integrations;

internal static class PR
{
    public static bool IsInstalled { get; } = Settings.CheckExternals.PRinstalled;


    // Ped related
    #region Ped
    /// <summary>
    /// Sets the ped's wanted status if Policing Redefined is installed, not synced with LSPDFR yet (May 2025, v0.0.2B).
    /// </summary>
    public static void SetWanted(Ped ped, bool isWanted = true)
    {
        if (!IsInstalled) return;
        SetWanted2(ped, isWanted);
    }

    private static void SetWanted2(Ped ped, bool isWanted = true)
        => CommonDataFramework.Modules.PedDatabase.PedDataController.GetPedData(ped).Wanted = isWanted;


    public static bool IsPedArrested(Ped ped)
    {
        if (!IsInstalled) return false;
        return IsPedArrested2(ped);
    }

    private static bool IsPedArrested2(Ped ped)
        => PolicingRedefined.API.PedAPI.IsPedArrested(ped);


    /// <summary>
    ///  give rand ped items
    /// </summary>
    public static void RandomPedItems(Ped ped)
    {
        if (!IsInstalled) return;
        RandomPedItems2(ped);
    }

    private static void RandomPedItems2(Ped ped)
    {
        PolicingRedefined.API.SearchItemsAPI.AddCustomPedSearchItem(new PolicingRedefined.Interaction.Assets.SearchItem("Pocket Knife", ped, PolicingRedefined.Interaction.Assets.EItemChance.VeryOften));
        PolicingRedefined.API.SearchItemsAPI.AddCustomPedSearchItem(new PolicingRedefined.Interaction.Assets.SearchItem("Used Needle", ped, PolicingRedefined.Interaction.Assets.EItemChance.Normal));
        PolicingRedefined.API.SearchItemsAPI.AddCustomPedSearchItem(new PolicingRedefined.Interaction.Assets.SearchItem("Small Bag of Marijuana", ped, PolicingRedefined.Interaction.Assets.EItemChance.Rare));
        PolicingRedefined.API.SearchItemsAPI.AddCustomPedSearchItem(new PolicingRedefined.Interaction.Assets.SearchItem("Stolen Wallet", ped, PolicingRedefined.Interaction.Assets.EItemChance.Rare));
        PolicingRedefined.API.SearchItemsAPI.AddCustomPedSearchItem(new PolicingRedefined.Interaction.Assets.SearchItem("Prescription Pills (No Label)", ped, PolicingRedefined.Interaction.Assets.EItemChance.Normal));
        PolicingRedefined.API.SearchItemsAPI.AddCustomPedSearchItem(new PolicingRedefined.Interaction.Assets.SearchItem("Unopened Pack of Syringes", ped, PolicingRedefined.Interaction.Assets.EItemChance.Rare));
        PolicingRedefined.API.SearchItemsAPI.AddCustomPedSearchItem(new PolicingRedefined.Interaction.Assets.SearchItem("Folded Knife", ped, PolicingRedefined.Interaction.Assets.EItemChance.Normal));
        PolicingRedefined.API.SearchItemsAPI.AddCustomPedSearchItem(new PolicingRedefined.Interaction.Assets.SearchItem("Bag of Pills (Various Types)", ped, PolicingRedefined.Interaction.Assets.EItemChance.Rare));
        PolicingRedefined.API.SearchItemsAPI.AddCustomPedSearchItem(new PolicingRedefined.Interaction.Assets.SearchItem("Counterfeit Money", ped, PolicingRedefined.Interaction.Assets.EItemChance.Rare));
        PolicingRedefined.API.SearchItemsAPI.AddCustomPedSearchItem(new PolicingRedefined.Interaction.Assets.SearchItem("Small Bottle of Unknown Liquid", ped, PolicingRedefined.Interaction.Assets.EItemChance.Normal));
    }


    public enum MCDrunkLevel
    {
        None,
        Tipsy,
        ModeratelyDrunk,
        VeryDrunk,
        Wasted,
        ShouldBeDead

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ped"></param>
    /// <param name="drunkLevel"></param>
    /// <param name="setWalkstyle">better set to false if the suspect should do a task afterwards</param>
    public static void SetDrunk(Ped ped, MCDrunkLevel drunkLevel = MCDrunkLevel.VeryDrunk, bool setWalkstyle = false)
    {
        if (!IsInstalled) return;
        SetDrunk2(ped, drunkLevel, setWalkstyle);
    }

    private static void SetDrunk2(Ped ped, MCDrunkLevel drunkLevel = MCDrunkLevel.VeryDrunk, bool setWalkstyle = false)
    {
        var mappedLevel = (PolicingRedefined.Interaction.Assets.PedAttributes.EDrunkLevel)(int)drunkLevel;
        PolicingRedefined.API.PedAPI.SetPedDrunk(ped, mappedLevel, setWalkstyle);
    }


    public enum MCDrugType
    {
        None = 0,
        Morphine = 1,
        Heroin = 2,
        Codeine = 4,
        Oxycodone = 8,
        Hydrocodone = 0x10,
        Fentanyl = 0x20,
        PCP = 0x40,
        LSD = 0x80,
        Mescaline = 0x100,
        Psilocybin = 0x200,
        Cannabis = 0x400,
        Adderall = 0x800,
        Concerta = 0x1000,
        Ritalin = 0x2000,
        Methamphetamine = 0x4000,
        Vyvanse = 0x8000,
        Cocaine = 0x10000,
        Risperdal = 0x20000,
        Seroquel = 0x40000,
        Abilify = 0x80000,
        Clozapine = 0x100000
    }

    /// <summary>
    /// Set the ped high on the chosen drug.
    /// </summary>
    public static void SetHigh(Ped ped, MCDrugType drugType = MCDrugType.Cannabis)
    {
        if (!IsInstalled) return;
        SetHigh2(ped, drugType);
    }

    private static void SetHigh2(Ped ped, MCDrugType drugType = MCDrugType.Cannabis)
    {
        var mappedType = (PolicingRedefined.Interaction.Assets.EDrugType)(int)drugType;
        PolicingRedefined.API.PedAPI.SetPedHigh(ped, mappedType);
    }

    /// <summary>
    /// Set the ped high on a random drug.
    /// </summary>
    public static void SetHigh(Ped ped)
    {
        if (!IsInstalled) return;
        SetHigh2(ped);
    }

    private static void SetHigh2(Ped ped)
        => PolicingRedefined.API.PedAPI.SetPedHigh(ped);


    #region Ped Documents
    public static void SetSuspendedLicense(Ped ped, bool toggle = true)
    {
        if (!IsInstalled) return;
        SetSuspendedLicense2(ped, toggle);
    }

    private static void SetSuspendedLicense2(Ped ped, bool toggle = true)
        => CommonDataFramework.Modules.PedDatabase.PedDataController.GetPedData(ped).DriversLicenseState = toggle ? LSPD_First_Response.Engine.Scripting.Entities.ELicenseState.Suspended : ELicenseState.Valid;
    #endregion Ped Documents
    #endregion Ped


    // Vehicle related
    #region Vehicle
    /// <summary>
    /// give rand vehicle items
    /// </summary>
    public static void RandomVehicleItems(Vehicle vehicle)
    {
        if (!IsInstalled) return;
        RandomVehicleItems2(vehicle);
    }

    private static void RandomVehicleItems2(Vehicle vehicle)
    {
        PolicingRedefined.API.SearchItemsAPI.AddCustomVehicleSearchItem(new PolicingRedefined.Interaction.Assets.SearchItem("Loaded Handgun", PolicingRedefined.Interaction.Assets.EItemLocation.DriverSeat, vehicle, PolicingRedefined.Interaction.Assets.EItemChance.Rare));
        PolicingRedefined.API.SearchItemsAPI.AddCustomVehicleSearchItem(new PolicingRedefined.Interaction.Assets.SearchItem("Open Alcohol Container (Beer Bottle)", PolicingRedefined.Interaction.Assets.EItemLocation.PassengerSeat, vehicle, PolicingRedefined.Interaction.Assets.EItemChance.Normal));
        PolicingRedefined.API.SearchItemsAPI.AddCustomVehicleSearchItem(new PolicingRedefined.Interaction.Assets.SearchItem("Stolen Credit Cards", PolicingRedefined.Interaction.Assets.EItemLocation.DriverSeat, vehicle, PolicingRedefined.Interaction.Assets.EItemChance.Rare));
        PolicingRedefined.API.SearchItemsAPI.AddCustomVehicleSearchItem(new PolicingRedefined.Interaction.Assets.SearchItem("Fake Driver's License", PolicingRedefined.Interaction.Assets.EItemLocation.DriverSeat, vehicle, PolicingRedefined.Interaction.Assets.EItemChance.Normal));
        PolicingRedefined.API.SearchItemsAPI.AddCustomVehicleSearchItem(new PolicingRedefined.Interaction.Assets.SearchItem("Bag of White Powder (Suspected Cocaine)", PolicingRedefined.Interaction.Assets.EItemLocation.Trunk, vehicle, PolicingRedefined.Interaction.Assets.EItemChance.Normal));
        PolicingRedefined.API.SearchItemsAPI.AddCustomVehicleSearchItem(new PolicingRedefined.Interaction.Assets.SearchItem("Unregistered Firearm", PolicingRedefined.Interaction.Assets.EItemLocation.BackLeftSeat, vehicle, PolicingRedefined.Interaction.Assets.EItemChance.Rare));
        PolicingRedefined.API.SearchItemsAPI.AddCustomVehicleSearchItem(new PolicingRedefined.Interaction.Assets.SearchItem("Large Amount of Cash (Band Wrapped)", PolicingRedefined.Interaction.Assets.EItemLocation.Trunk, vehicle, PolicingRedefined.Interaction.Assets.EItemChance.Rare));
        PolicingRedefined.API.SearchItemsAPI.AddCustomVehicleSearchItem(new PolicingRedefined.Interaction.Assets.SearchItem("Burglary Tools (Crowbar, Lock Picks)", PolicingRedefined.Interaction.Assets.EItemLocation.Trunk, vehicle, PolicingRedefined.Interaction.Assets.EItemChance.Normal));
        PolicingRedefined.API.SearchItemsAPI.AddCustomVehicleSearchItem(new PolicingRedefined.Interaction.Assets.SearchItem("Ski Mask and Gloves", PolicingRedefined.Interaction.Assets.EItemLocation.BackRightSeat, vehicle, PolicingRedefined.Interaction.Assets.EItemChance.Normal));
        PolicingRedefined.API.SearchItemsAPI.AddCustomVehicleSearchItem(new PolicingRedefined.Interaction.Assets.SearchItem("Prescription Pills (No Label)", PolicingRedefined.Interaction.Assets.EItemLocation.DriverSeat, vehicle, PolicingRedefined.Interaction.Assets.EItemChance.Normal));
        PolicingRedefined.API.SearchItemsAPI.AddCustomVehicleSearchItem(new PolicingRedefined.Interaction.Assets.SearchItem("Backpack with Syringes", PolicingRedefined.Interaction.Assets.EItemLocation.BackLeftSeat, vehicle, PolicingRedefined.Interaction.Assets.EItemChance.Rare));
        PolicingRedefined.API.SearchItemsAPI.AddCustomVehicleSearchItem(new PolicingRedefined.Interaction.Assets.SearchItem("Taser (Non-Law Enforcement)", PolicingRedefined.Interaction.Assets.EItemLocation.BackRightSeat, vehicle, PolicingRedefined.Interaction.Assets.EItemChance.Rare));
        PolicingRedefined.API.SearchItemsAPI.AddCustomVehicleSearchItem(new PolicingRedefined.Interaction.Assets.SearchItem("Fake Police Badge", PolicingRedefined.Interaction.Assets.EItemLocation.DriverSeat, vehicle, PolicingRedefined.Interaction.Assets.EItemChance.VeryRare));
        PolicingRedefined.API.SearchItemsAPI.AddCustomVehicleSearchItem(new PolicingRedefined.Interaction.Assets.SearchItem("Small Package of Methamphetamine", PolicingRedefined.Interaction.Assets.EItemLocation.Trunk, vehicle, PolicingRedefined.Interaction.Assets.EItemChance.Rare));
        PolicingRedefined.API.SearchItemsAPI.AddCustomVehicleSearchItem(new PolicingRedefined.Interaction.Assets.SearchItem("Briefcase with Confidential Documents", PolicingRedefined.Interaction.Assets.EItemLocation.Trunk, vehicle, PolicingRedefined.Interaction.Assets.EItemChance.VeryRare));
    }


    public static void SetStolen(Vehicle vehicle, bool toggle = true)
    {
        if (!IsInstalled) return;
        SetStolen2(vehicle, toggle);
    }

    private static void SetStolen2(Vehicle vehicle, bool toggle = true)
        => CommonDataFramework.Modules.VehicleDatabase.VehicleDataController.GetVehicleData(vehicle).IsStolen = toggle;


    #region Vehicle Documents
    /// <summary>
    /// expired license
    /// </summary>
    public static void SetExpiredLicense(Ped ped, bool toggle = true)
    {
        if (!IsInstalled) return;
        SetExpiredLicense2(ped, toggle);
    }

    private static void SetExpiredLicense2(Ped ped, bool toggle = true)
        => CommonDataFramework.Modules.PedDatabase.PedDataController.GetPedData(ped).DriversLicenseState = toggle ? LSPD_First_Response.Engine.Scripting.Entities.ELicenseState.Expired : ELicenseState.Valid;


    /// <summary>
    ///  expired insurance
    /// </summary>
    public static void SetExpiredInsurance(Vehicle vehicle, bool toggle = true)
    {
        if (!IsInstalled) return;
        SetExpiredInsurance2(vehicle, toggle);
    }

    private static void SetExpiredInsurance2(Vehicle vehicle, bool toggle = true)
    {
        var insurance = CommonDataFramework.Modules.VehicleDatabase.VehicleDataController.GetVehicleData(vehicle).Insurance;
        insurance.Status = toggle ? CommonDataFramework.Modules.EDocumentStatus.Expired : CommonDataFramework.Modules.EDocumentStatus.Valid;
        // could set expiration date, i assume PR does it for me?
    }

    /// <summary>
    /// expired registration
    /// </summary>
    public static void SetExpiredRegistration(Vehicle vehicle, bool toggle = true)
    {
        if (!IsInstalled) return;
        SetExpiredRegistration2(vehicle, toggle);
    }

    private static void SetExpiredRegistration2(Vehicle vehicle, bool toggle = true)
    {
        var registration = CommonDataFramework.Modules.VehicleDatabase.VehicleDataController.GetVehicleData(vehicle).Registration;
        registration.Status = toggle ? CommonDataFramework.Modules.EDocumentStatus.Expired : CommonDataFramework.Modules.EDocumentStatus.Valid;
        // could set expiration date...
    }
    #endregion Vehicle Documents
    #endregion Vehicle
}