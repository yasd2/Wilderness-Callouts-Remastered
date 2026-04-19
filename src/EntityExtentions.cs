using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;

namespace WildernessCallouts
{
    internal static class EntityExtentions
    {
        public static void DeleteIfExists(this Entity entity)
        {
            if (entity.Exists()) entity.Delete();
        }

        public static void DismissIfExists(this Entity entity)
        {
            if (entity.Exists()) entity.Dismiss();
        }
    }
}
