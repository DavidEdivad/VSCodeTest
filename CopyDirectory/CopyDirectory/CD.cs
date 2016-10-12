using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyDirectory
{
    #region CLASS COPY DIRECTORY

    public class CD 
    {
        public delegate void dgEventRaiser(string item);
        public event dgEventRaiser OnCopyItem;

        public void CopyDirectory(string Source, string Destination)
        {
            String[] Files;

            if (Destination[Destination.Length - 1] != Path.DirectorySeparatorChar)
            {
                Destination += Path.DirectorySeparatorChar;
            }

            if (!Directory.Exists(Destination))
            {
                Directory.CreateDirectory(Destination);
            }

            Files = Directory.GetFileSystemEntries(Source);

            foreach (var item in Files)
            {
                if (Directory.Exists(item))
                {
                    OnCopyItem(item); 
                    CopyDirectory(item, Destination + Path.GetFileName(item));                                                         
                }
                else
                {
                    OnCopyItem(item); 
                    File.Copy(item, Destination + Path.GetFileName(item), true);                    
                }
            }

        }
    }
    #endregion

}
