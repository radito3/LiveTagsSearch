using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LiveTagsSearch.Models
{
    public class ImageFile : AbstractRenderableFile
    {
        private readonly FileStream _content;
        
        public override string Content
        {
            get
            {
                IList<byte[]> bytesList = new List<byte[]>();
                byte[] buff = new byte[255];
                while (_content.Read(buff, 0, 255) != -1)
                {
                    bytesList.Add(buff);
                }
                byte[] array = bytesList.SelectMany(i => i).ToArray();
                return System.Convert.ToBase64String(array);
            }
        }
        
        public override string Type => "image";
        public override string IconPath => "assets/picture-icon.png";

        public ImageFile(string name) : base(name)
        {
            _content = File.OpenRead(name);
        }
    }
}
