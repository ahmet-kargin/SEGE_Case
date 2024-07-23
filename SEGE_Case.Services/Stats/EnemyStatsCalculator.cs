namespace SEGE_Case.Services.Stats;

public class EnemyStatsCalculator
{
    public int EnemyHP(int Alchemy, int Archery, int Dexterity, int Endurance, int Intelligence, int Luck, int Perception, int Resilience, int Stealth, int Strength, int Wisdom, int Level, int Rarity, int StarCount, int PinkStarCount)
    {
        var b = 2.14; 
        var c = 0.2 * Level; 
        var d = 0.5; 
        var r = Rarity;
        var MaxLevel = StarCount * 10;
        var p = 1.06;
        return Convert.ToInt32(Math.Round((Strength + Endurance) * Math.Pow(c, Level / MaxLevel) * StarCount * Math.Pow(b, d) * Math.Pow(p, PinkStarCount) * Math.Pow(4, r) + (Math.Pow(4, Rarity) * 15)));
    }

    public int EnemyATK(int Alchemy, int Archery, int Dexterity, int Endurance, int Intelligence, int Luck, int Perception, int Resilience, int Stealth, int Strength, int Wisdom, int Level, int Rarity, int StarCount, int PinkStarCount)
    {
        var b = 2.14;
        var c = 0.2 * Level;
        var d = 0.5;
        var r = Rarity;
        var MaxLevel = StarCount * 10;
        var p = 1.06;

        return Convert.ToInt32(Math.Round(((((Dexterity + Perception + Alchemy + Archery) * (Math.Pow(c, Level / MaxLevel) / 2) * StarCount * Math.Pow(b, d) * Math.Pow(p, PinkStarCount))) * Math.Pow(4, r) / 8) + 1));
    }

    public int EnemyDEF(int Alchemy, int Archery, int Dexterity, int Endurance, int Intelligence, int Luck, int Perception, int Resilience, int Stealth, int Strength, int Wisdom, int Level, int Rarity, int StarCount, int PinkStarCount)
    {
        var b = 2.14;
        var c = 0.2 * Level;
        var d = 0.0338;
        var r = Rarity;
        var MaxLevel = StarCount * 10;
        var p = 1.06;

        return Convert.ToInt32(Math.Round((((Resilience + Stealth) * (Math.Pow(c, Level / MaxLevel) / 2) * StarCount * Math.Pow(b, d) * Math.Pow(p, PinkStarCount) / 2) * Math.Pow(4, r) / 8) + 5));
    }

    public int EnemySPD(int Alchemy, int Archery, int Dexterity, int Endurance, int Intelligence, int Luck, int Perception, int Resilience, int Stealth, int Strength, int Wisdom, int Level, int Rarity, int StarCount, int PinkStarCount)
    {
        var b = 1.07;
        var c = 0.2 * Level;
        var d = 0.0116;
        var r = Rarity;
        var MaxLevel = StarCount * 10;
        var p = 1.06;

        return Convert.ToInt32(Math.Round(((Endurance + Resilience) * (Math.Pow(c, Level / MaxLevel) / 2) * StarCount * (Math.Pow(b, d) / 100) * Math.Pow(p, PinkStarCount) / 2) * (r + 1) + 5));
    }

    public double EnemyCRATE(int Alchemy, int Archery, int Dexterity, int Endurance, int Intelligence, int Luck, int Perception, int Resilience, int Stealth, int Strength, int Wisdom, int Level, int Rarity, int StarCount, int PinkStarCount)
    {
        var b = 1.07;
        var c = 0.2 * Level;
        var d = 0.0116;
        var r = Rarity;
        var MaxLevel = StarCount * 10;
        var p = 1.06;

        return (((Luck + Perception + Wisdom) * (Math.Pow(c, Level / MaxLevel) / 2) * StarCount * (Math.Pow(b, d) / 100) * Math.Pow(p, PinkStarCount) * (r + 1) / (100)));
    }

    public double EnemyCDMG(int Alchemy, int Archery, int Dexterity, int Endurance, int Intelligence, int Luck, int Perception, int Resilience, int Stealth, int Strength, int Wisdom, int Level, int Rarity, int StarCount, int PinkStarCount)
    {
        var b = 1.07;
        var c = 0.2 * Level;
        var d = 0.0116;
        var r = Rarity;
        var MaxLevel = StarCount * 10;
        var p = 1.06;

        return ((Luck + Intelligence + Wisdom) * (Math.Pow(c, Level / MaxLevel) / 2) * StarCount * (Math.Pow(b, d) / 100) * Math.Pow(p, PinkStarCount) * (r + 1) + 100);
    }

    public int EnemyRES(int Alchemy, int Archery, int Dexterity, int Endurance, int Intelligence, int Luck, int Perception, int Resilience, int Stealth, int Strength, int Wisdom, int Level, int Rarity, int StarCount, int PinkStarCount)
    {
        var b = 1.07;
        var c = 0.2 * Level;
        var d = 0.0116; 
        var r = Rarity;
        var MaxLevel = StarCount * 10;
        var p = 1.06;

        return Convert.ToInt32(Math.Round(((Strength + Stealth) * (Math.Pow(c, Level / MaxLevel)) * (StarCount) * (Math.Pow(b, d) / 100) * Math.Pow(p, PinkStarCount)) * (r + 1) + 5));
    }

    public int EnemyACC(int Alchemy, int Archery, int Dexterity, int Endurance, int Intelligence, int Luck, int Perception, int Resilience, int Stealth, int Strength, int Wisdom, int Level, int Rarity, int StarCount, int PinkStarCount)
    {
        var b = 1;
        var c = 0.2 * Level;
        var d = 0.0116;
        var r = Rarity;
        var MaxLevel = StarCount * 10;
        var p = 1.06;

        return Convert.ToInt32(Math.Round(((Dexterity + Intelligence) * (Math.Pow(c, Level / MaxLevel)) * StarCount * (Math.Pow(b, d) / 100) * Math.Pow(p, PinkStarCount) * (r + 1)) + 5));
    }
}
