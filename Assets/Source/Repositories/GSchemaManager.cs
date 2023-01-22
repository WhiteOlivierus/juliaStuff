public class GSchemaManager : Singleton<GSchemaManager>
{
    private readonly IGSchemaRepository gSchemaRepository = new GSchemaRepository();

    public bool SetText(string text, string propertyName)
    {
        if (string.IsNullOrEmpty(text))
        {
            return false;
        }

        gSchemaRepository.SetEvent(propertyName);

        return true;
    }
}
