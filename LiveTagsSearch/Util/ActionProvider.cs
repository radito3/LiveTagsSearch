using System;
using System.Collections.Generic;

namespace LiveTagsSearch.Util
{
    public class ActionProvider<TIn, TOut>
    {
        public static string[] GetFilesDirectories(string path)
        {
            ActionProvider<string, string[]> ap1 = new FilesAction();
            ActionProvider<string, string[]> ap2 = new DirectoriesAction();
            ActionProvider<IEnumerable<string[]>, string[]> combiner = new CombinerAction();
            return combiner.Action(new [] { ap1.Action(path), ap2.Action(path) });
        }
        
        public virtual TOut Action(TIn arg)
        {
            throw new ArgumentException();
        }
    }
}
