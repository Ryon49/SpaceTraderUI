using SpaceTraderUI.Model;

namespace SpaceTraderUI.Services;

/// <summary>
/// A placeholder for list of factions after fetch from SpaceTrader API, 
/// to reduce recurrent request.
/// </summary>
public class FactionService
{
    public List<Faction>? Factions;
}