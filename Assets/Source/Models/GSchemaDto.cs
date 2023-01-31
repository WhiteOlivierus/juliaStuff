using System.Collections.Generic;
using System.Linq;

public class GSchemaDto
{
    public string Event { get; set; }

    public IEnumerable<Feeling> Feelings { get; set; }

    public IEnumerable<string> Thoughts { get; set; } = Enumerable.Empty<string>();

    public IEnumerable<string> Behavior { get; set; }

    public IEnumerable<string> Consequences { get; set; }

    public int MainThoughtId { get; set; } = 0;

    public int MainThougthPercentage { get; set; }

    public IEnumerable<string> BadArguments { get; set; }

    public IEnumerable<string> GoodArguments { get; set; }
}
