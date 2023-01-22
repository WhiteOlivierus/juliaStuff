using System.Collections.Generic;

public class GSchemaResult
{
    public GSchemaDto Schema { get; set; }

    public int MainThoughtId { get; set; }

    public IEnumerable<int> HelpingArguments { get; set; }
}
