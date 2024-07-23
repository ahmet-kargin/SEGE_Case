using Amazon.DynamoDBv2.DataModel;

namespace SEGE_Case.Domain.Entities;

[DynamoDBTable("Enemies")]
public class Enemy 
{
    [DynamoDBHashKey]
    public string EnemyId { get; set; }
    public string Name { get; set; }
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
    public int Level { get; set; }
    public int Rarity { get; set; }
    public int StarCount { get; set; }
    public int PinkStarCount { get; set; }

    // Calculated attributes
    public int HP { get; set; }
    public int ATK { get; set; }
    public int DEF { get; set; }
    public int SPD { get; set; }
    public double CRATE { get; set; }
    public double CDMG { get; set; }
    public int RES { get; set; }
    public int ACC { get; set; }
}
