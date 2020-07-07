using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Modifier
{
    public abstract void ModifyAppliance(Appliance appliance);

    public static Modifier GetByName(string name)
    {
        switch (name)
        {
            case "HorizontalFlip":
                return new HorizontalFlipModifier();
            default:
                return null;
        }
    }
}
