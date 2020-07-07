using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ApplianceData
{
    protected Dictionary<string, object> data;

    public ApplianceData()
    {
        data = new Dictionary<string, object>();
    }

    public void AddData(string name, object data)
    {
        this.data.Add(name, data);
    }

    public bool TryGetData(string dataName, out object data)
    {
        if (!this.data.ContainsKey(dataName))
        {
            data = null;
            return false;
        }

        data = this.data[dataName];

        return true;
    }
}
