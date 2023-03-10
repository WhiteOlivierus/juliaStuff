using System.Collections.Generic;

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
