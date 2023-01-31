using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GSchemaManager : Singleton<GSchemaManager>
{
    private GSchemaDto gSchemaDto = new();

    public void SetEvent(string eventText)
    {
        Debug.Log(eventText);
        gSchemaDto.Event = eventText;
    }

    public void SetFeelings(IEnumerable<Feeling> feelingsList)
    {
        Debug.Log(string.Join(", ", feelingsList.Select(feeling => $"{feeling.Emotion}:{feeling.Percentage}")));
        gSchemaDto.Feelings = feelingsList;
    }

    public void SetThoughts(IEnumerable<string> thoughtsList)
    {
        Debug.Log(string.Join(", ", thoughtsList));
        gSchemaDto.Thoughts = thoughtsList.Where(thought => !string.IsNullOrEmpty(thought));
    }

    public void SetBehavior(IEnumerable<string> behaviorList)
    {
        Debug.Log(string.Join(", ", behaviorList));
        gSchemaDto.Behavior = behaviorList;
    }

    public void SetConsequences(IEnumerable<string> consequencesList)
    {
        Debug.Log(string.Join(", ", consequencesList));
        gSchemaDto.Consequences = consequencesList;
    }

    public void SetMainThought(int mainThoughtId)
    {
        gSchemaDto.MainThoughtId = mainThoughtId;
        Debug.Log(GetMainThought());
    }

    public void SetMainThoughtPercentage(Single mainThoughtPercentage)
    {
        gSchemaDto.MainThougthPercentage = (int)mainThoughtPercentage;
        Debug.Log(gSchemaDto.MainThougthPercentage);
    }

    public void SetBadArguments(IEnumerable<string> badArguments)
    {
        Debug.Log(string.Join(", ", badArguments));
        gSchemaDto.BadArguments = badArguments;
    }

    public void AddGoodArguments(string goodArguments)
    {
        Debug.Log(goodArguments);
        gSchemaDto.GoodArguments = gSchemaDto.GoodArguments.Append(goodArguments);
    }

    public string GetEvent()
    {
        return gSchemaDto.Event;
    }

    public IEnumerable<Feeling> GetFeelings()
    {
        return gSchemaDto.Feelings;
    }

    public IEnumerable<string> GetThoughts()
    {
        return gSchemaDto.Thoughts;
    }

    public IEnumerable<string> GetBehavior()
    {
        return gSchemaDto.Behavior;
    }

    public IEnumerable<string> GetConsequences()
    {
        return gSchemaDto.Consequences;
    }

    public string GetMainThought()
    {
        return gSchemaDto.Thoughts.Any() ? gSchemaDto.Thoughts.ToList()[gSchemaDto.MainThoughtId] : string.Empty;
    }

    public int GetMainThoughtPercentage()
    {
        return gSchemaDto.MainThougthPercentage;
    }

    public IEnumerable<string> GetBadArguments()
    {
        return gSchemaDto.BadArguments;
    }

    public IEnumerable<string> GetGoodArgument()
    {
        return gSchemaDto.GoodArguments;
    }
}
