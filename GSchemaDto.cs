using System.Collections.Generic;

public class GSchemaResult
{
    public GSchemaDto Schema { get; set; }

    public int MainThoughtId { get; set; }

    public IEnumerable<int> HelpingArguments { get; set; }
}

public class GSchemaDto
{
    public string Event { get; set; }

    public IEnumerable<Feeling> Feelings { get; set; }

    public IEnumerable<string> Thoughts { get; set; }

    public IEnumerable<string> Behavior { get; set; }

    public IEnumerable<string> Consequences { get; set; }

    public int MainThoughtId { get; set; }

    public int MainThougthPercentage { get; set; }

    public IEnumerable<string> BadArguments { get; set; }

    public IEnumerable<string> GoodArguments { get; set; }
}

public class Feeling
{
    public Emotion Emotion { get; set; }

    public int Percentage { get; set; }
}

public enum Emotion
{
    Happy,
    Angry,
    Anxious,
    Sad,
    Ashamed
}
