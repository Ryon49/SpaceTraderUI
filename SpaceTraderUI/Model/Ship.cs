#nullable disable
// Generated through quicktype C#

using System;
using System.Collections.Generic;

using System.Text.Json.Serialization;

namespace SpaceTraderUI.Model;

public class Ship
{
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }

    [JsonPropertyName("nav")]
    public Nav Nav { get; set; }

    [JsonPropertyName("crew")]
    public Crew Crew { get; set; }

    [JsonPropertyName("fuel")]
    public Fuel Fuel { get; set; }

    [JsonPropertyName("frame")]
    public Frame Frame { get; set; }

    [JsonPropertyName("reactor")]
    public Reactor Reactor { get; set; }

    [JsonPropertyName("engine")]
    public Engine Engine { get; set; }

    [JsonPropertyName("modules")]
    public List<Module> Modules { get; set; }
}

public partial class Crew
{
    [JsonPropertyName("current")]
    public long Current { get; set; }

    [JsonPropertyName("capacity")]
    public long Capacity { get; set; }

    [JsonPropertyName("required")]
    public long CrewRequired { get; set; }

    [JsonPropertyName("rotation")]
    public string Rotation { get; set; }

    [JsonPropertyName("morale")]
    public long Morale { get; set; }

    [JsonPropertyName("wages")]
    public long Wages { get; set; }
}

public partial class Engine
{
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("condition")]
    public long Condition { get; set; }

    [JsonPropertyName("speed")]
    public long Speed { get; set; }

    [JsonPropertyName("requirements")]
    public EngineRequirements Requirements { get; set; }
}

public partial class EngineRequirements
{
    [JsonPropertyName("power")]
    public long Power { get; set; }

    [JsonPropertyName("crew")]
    public long Crew { get; set; }
}

public partial class Frame
{
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("moduleSlots")]
    public long ModuleSlots { get; set; }

    [JsonPropertyName("mountingPoints")]
    public long MountingPoints { get; set; }

    [JsonPropertyName("fuelCapacity")]
    public long FuelCapacity { get; set; }

    [JsonPropertyName("condition")]
    public long Condition { get; set; }

    [JsonPropertyName("requirements")]
    public EngineRequirements Requirements { get; set; }
}

public partial class Fuel
{
    [JsonPropertyName("current")]
    public long Current { get; set; }

    [JsonPropertyName("capacity")]
    public long Capacity { get; set; }

    [JsonPropertyName("consumed")]
    public Consumed Consumed { get; set; }
}

public partial class Consumed
{
    [JsonPropertyName("amount")]
    public long Amount { get; set; }

    [JsonPropertyName("timestamp")]
    public DateTimeOffset Timestamp { get; set; }
}

public partial class Module
{
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("capacity")]
    public long? Capacity { get; set; }

    [JsonPropertyName("requirements")]
    public ModuleRequirements Requirements { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("range")]
    public long? Range { get; set; }
}

public partial class ModuleRequirements
{
    [JsonPropertyName("crew")]
    public long Crew { get; set; }

    [JsonPropertyName("power")]
    public long Power { get; set; }

    [JsonPropertyName("slots")]
    public long Slots { get; set; }
}

public partial class Nav
{
    [JsonPropertyName("systemSymbol")]
    public string SystemSymbol { get; set; }

    [JsonPropertyName("waypointSymbol")]
    public string WaypointSymbol { get; set; }

    [JsonPropertyName("route")]
    public Route Route { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("flightMode")]
    public string FlightMode { get; set; }
}

public partial class Route
{
    [JsonPropertyName("departure")]
    public Departure Departure { get; set; }

    [JsonPropertyName("destination")]
    public Departure Destination { get; set; }

    [JsonPropertyName("arrival")]
    public DateTimeOffset Arrival { get; set; }

    [JsonPropertyName("departureTime")]
    public DateTimeOffset DepartureTime { get; set; }
}

public partial class Departure
{
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("systemSymbol")]
    public string SystemSymbol { get; set; }

    [JsonPropertyName("x")]
    public long X { get; set; }

    [JsonPropertyName("y")]
    public long Y { get; set; }
}

public partial class Reactor
{
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("condition")]
    public long Condition { get; set; }

    [JsonPropertyName("powerOutput")]
    public long PowerOutput { get; set; }

    [JsonPropertyName("requirements")]
    public ReactorRequirements Requirements { get; set; }
}

public partial class ReactorRequirements
{
    [JsonPropertyName("crew")]
    public long Crew { get; set; }
}
