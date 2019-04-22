using System.Collections.Generic;
using System.Linq;

namespace LiveTagsSearch.Util
{
    internal class CombinerAction : ActionProvider<IEnumerable<string[]>, string[]>
    {
        public override string[] Action(IEnumerable<string[]> args)
        {
            return args.SelectMany(i => i).Distinct().ToArray();
        }
    }    
}
