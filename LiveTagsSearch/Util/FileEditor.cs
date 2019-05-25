using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LiveTagsSearch.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace LiveTagsSearch.Util
{
    public static class FileEditor
    {
        //file format ->
        /*
         *    [
         *        { "path": <full_path>, "tags": [ "tag1", "tag2", ...] },
         *        ...
         *    ]
         * 
         */

        //the indexing should be fixed to not error on empty array and to retrieve proper values on reading
        public static void WriteToFile(string fullPath, IEnumerable<string> tags)
        {
            var str = File.ReadAllText("tagged_files.txt", Encoding.UTF8);
            if (str.Contains(fullPath, StringComparison.Ordinal))
            {
                var pathIdx = str.IndexOf(fullPath, StringComparison.Ordinal);
                var arrIdx = str.IndexOf("\"tags\":[", pathIdx, StringComparison.Ordinal);
                var start = arrIdx + "\"tags\":[".Length;
                var end = str.IndexOf(']', arrIdx) - start;
                var origTags = str.Substring(start, end);
                str = str.Replace(origTags, tags.Join(","));
            }
            else
            {
                var entry = Environment.NewLine +
                            "{\"path\":\"" + fullPath + "\",\"tags\":[" + tags.Select(t => "\"" + t + "\"").Join(",") + "]}";
                var hasEntries = str.LastIndexOf('}');
                str = str.Insert(hasEntries != -1 ? hasEntries + 1 : str.IndexOf('[') + 1, entry);
            }
            File.WriteAllText("tagged_files.txt", str);
        }

        public static IEnumerable<IFile> MapWithTags(this IEnumerable<IFile> stream)
        {
            var str = File.ReadAllText("tagged_files.txt", Encoding.UTF8);
            return stream.Select(file =>
            {
                var fullPath = Path.GetFullPath(file.Name);
                if (str.Contains(fullPath, StringComparison.Ordinal))
                {
                    var pathIdx = str.IndexOf(fullPath, StringComparison.Ordinal);
                    var arrIdx = str.IndexOf("\"tags\":[", pathIdx, StringComparison.Ordinal);
                    var start = arrIdx + "\"tags\":".Length;
                    var end = str.IndexOf(']', arrIdx) - start;
                    var tags = str.Substring(start, end);
                    file.Tags = tags.Split(',').ToList();
                }
                return file;
            });
        }
    }
}