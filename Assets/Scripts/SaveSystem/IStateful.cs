using System.Collections.Generic;

public interface IStateful
{
    public Dictionary<string, string> GetState();
    public void SetState(Dictionary<string,string> keyValuePairs);
    public string GetObjectName();

}
