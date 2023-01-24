using System.Collections.Generic;
using System.Linq;

public class GSchemaManager : Singleton<GSchemaManager>
{
    private readonly GSchemaDto gSchemaDto = new();

    public void SetEvent(string eventText) => gSchemaDto.Event = eventText;

    public void SetThoughts(IEnumerable<Feeling> feelingsList) => gSchemaDto.Feelings = feelingsList;

    public void SetThoughts(IEnumerable<string> thoughtsList) => gSchemaDto.Thoughts = thoughtsList;

    public void SetBehavior(IEnumerable<string> behaviorList) => gSchemaDto.Behavior = behaviorList;

    public void SetConsequences(IEnumerable<string> consequencesList) => gSchemaDto.Consequences = consequencesList;

    public void SetMainThought(int mainThoughtId) => gSchemaDto.MainThoughtId = mainThoughtId;

    public void SetMainThoughtPercentage(int mainThoughtPercentage) => gSchemaDto.MainThougthPercentage = mainThoughtPercentage;

    public void SetBadArguments(IEnumerable<string> badArguments) => gSchemaDto.BadArguments = badArguments;

    public void AddGoodArguments(string goodArguments) => gSchemaDto.GoodArguments = gSchemaDto.GoodArguments.Append(goodArguments);
}
