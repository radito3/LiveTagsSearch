using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AspNetSpa1.Models
{
    public class ImageFile : AbstractFile
    {
        private FileStream _content;
        
        public override string Content
        {
            get
            {
                IList<byte[]> byteses = new List<byte[]>();
                byte[] buff = new byte[255];
                while (_content.Read(buff, 0, 255) != -1)
                {
                    byteses.Add(buff);
                }
                byte[] array = byteses.SelectMany(i => i).ToArray();
                return System.Convert.ToBase64String(array);
            }
        }

        public ImageFile(string name) : base(name)
        {
            _content = File.OpenRead(name);
        }

        public override bool IsRenderable()
        {
            throw new System.NotImplementedException();
        }

        public override void AddTag(string tag)
        {
            throw new System.NotImplementedException();
        }

        public override void DeleteTag(string tag)
        {
            throw new System.NotImplementedException();
        }
    }
}