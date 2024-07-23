namespace SEGE_Case.Services.Stats;

public class HeroStatsCalculator
{
    public int HeroHP(int Alchemy, int Archery, int Dexterity, int Endurance, int Intelligence, int Luck, int Perception,
        int Resilience, int Stealth, int Strength, int Wisdom, int Level, int Rarity, int StarCount, int PinkStarCount)
    {
        double b = 2.14;
        double c = 0.2 * Level;
        double d = 0.0338;
        int r = Rarity;
        int MaxLevel = StarCount * 10;
        double p = 1.06;

        return (int)Math.Round((Strength + Endurance) * Math.Pow(c, (double)Level / MaxLevel) * StarCount
            * Math.Pow(b, d) * Math.Pow(p, PinkStarCount) * Math.Pow(4, r) + 300);
    }

    public int HeroATK(int Alchemy, int Archery, int Dexterity, int Endurance, int Intelligence, int Luck, int Perception,
        int Resilience, int Stealth, int Strength, int Wisdom, int Level, int Rarity, int StarCount, int PinkStarCount)
    {
        double b = 2.14;
        double c = 0.2 * Level;
        double d = 0.5;
        int r = Rarity;
        int MaxLevel = StarCount * 10;
        double p = 1.06;

        return (int)Math.Round(((((Dexterity + Perception + Alchemy + Archery) * Math.Pow(c, (double)Level / MaxLevel) / 2) * StarCount
            * Math.Pow(b, d) * Math.Pow(p, PinkStarCount) / 2) * Math.Pow(4, r) / 8) + 15);
    }

    public int HeroDEF(int Alchemy, int Archery, int Dexterity, int Endurance, int Intelligence, int Luck, int Perception,
        int Resilience, int Stealth, int Strength, int Wisdom, int Level, int Rarity, int StarCount, int PinkStarCount)
    {
        double b = 2.14;
        double c = 0.2 * Level;
        double d = 0.0338;
        int r = Rarity;
        int MaxLevel = StarCount * 10;
        double p = 1.06;

        return (int)Math.Round((((Resilience + Stealth) * Math.Pow(c, (double)Level / MaxLevel) / 2) * StarCount
            * Math.Pow(b, d) * Math.Pow(p, PinkStarCount) / 2) * Math.Pow(4, r) / 8 + 1);
    }

    public int HeroSPD(int Alchemy, int Archery, int Dexterity, int Endurance, int Intelligence, int Luck, int Perception,
        int Resilience, int Stealth, int Strength, int Wisdom, int Level, int Rarity, int StarCount, int PinkStarCount)
    {
        double b = 1.07;
        double c = 0.2 * Level;
        double d = 0.0116;
        int r = Rarity;
        int MaxLevel = StarCount * 10;
        double p = 1.06;

        return (int)Math.Round((Endurance + Resilience) * Math.Pow(c, (double)Level / MaxLevel) / 2 * StarCount
            * Math.Pow(b, d) / 100 * Math.Pow(p, PinkStarCount) / 2 * (r + 1) + 5);
    }

    public double HeroCRATE(int Alchemy, int Archery, int Dexterity, int Endurance, int Intelligence, int Luck, int Perception,
        int Resilience, int Stealth, int Strength, int Wisdom, int Level, int Rarity, int StarCount, int PinkStarCount)
    {
        double b = 1.07;
        double c = 0.2 * Level;
        double d = 0.0116;
        int r = Rarity;
        int MaxLevel = StarCount * 10;
        double p = 1.06;

        return ((Luck + Perception + Wisdom) * Math.Pow(c, (double)Level / MaxLevel) / 2 * StarCount
            * Math.Pow(b, d) / 100 * Math.Pow(p, PinkStarCount) * (r + 1) / 100);
    }

    public double HeroCDMG(int Alchemy, int Archery, int Dexterity, int Endurance, int Intelligence, int Luck, int Perception,
        int Resilience, int Stealth, int Strength, int Wisdom, int Level, int Rarity, int StarCount, int PinkStarCount)
    {
        double b = 1.07;
        double c = 0.2 * Level;
        double d = 0.0116;
        int r = Rarity;
        int MaxLevel = StarCount * 10;
        double p = 1.06;

        return ((Luck + Intelligence + Wisdom) * Math.Pow(c, (double)Level / MaxLevel) / 2 * StarCount
            * Math.Pow(b, d) / 100 * Math.Pow(p, PinkStarCount) * (r + 1) + 100);
    }

    public int HeroRES(int Alchemy, int Archery, int Dexterity, int Endurance, int Intelligence, int Luck, int Perception,
        int Resilience, int Stealth, int Strength, int Wisdom, int Level, int Rarity, int StarCount, int PinkStarCount)
    {
        double b = 1.07;
        double c = 0.2 * Level;
        double d = 0.0116;
        int r = Rarity;
        int MaxLevel = StarCount * 10;
        double p = 1.06;

        return (int)Math.Round((Strength + Stealth) * Math.Pow(c, (double)Level / MaxLevel) * StarCount
            * Math.Pow(b, d) / 100 * Math.Pow(p, PinkStarCount) * (r + 1) + 5);
    }

    public int HeroACC(int Alchemy, int Archery, int Dexterity, int Endurance, int Intelligence, int Luck, int Perception,
        int Resilience, int Stealth, int Strength, int Wisdom, int Level, int Rarity, int StarCount, int PinkStarCount)
    {
        double b = 1;
        double c = 0.2 * Level;
        double d = 0.0116;
        int r = Rarity;
        int MaxLevel = StarCount * 10;
        double p = 1.06;

        return (int)Math.Round((Dexterity + Intelligence) * Math.Pow(c, (double)Level / MaxLevel) * StarCount
            * Math.Pow(b, d) / 100 * Math.Pow(p, PinkStarCount) * (r + 1) + 5);
    }
}

