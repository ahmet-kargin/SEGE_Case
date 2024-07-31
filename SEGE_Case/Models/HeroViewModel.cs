using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SEGE_Case.WebUI.Models;

public class HeroViewModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId HeroId { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    public int Rarity { get; set; }
    public int StarCount { get; set; }
    public int PinkStarCount { get; set; }

    public int Alchemy { get; set; }
    public int Archery { get; set; }
    public int Dexterity { get; set; }
    public int Endurance { get; set; }
    public int Intelligence { get; set; }
    public int Luck { get; set; }
    public int Perception { get; set; }
    public int Resilience { get; set; }
    public int Stealth { get; set; }
    public int Strength { get; set; }
    public int Wisdom { get; set; }
}

