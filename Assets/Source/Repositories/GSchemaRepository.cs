public class GSchemaRepository : IGSchemaRepository
{
    private static readonly GSchemaDto gSchemaDto = new();

    public void SetEvent(string eventText)
    {
        gSchemaDto.Event = eventText;
    }
}

public interface IGSchemaRepository
{
    void SetEvent(string eventText);
}
