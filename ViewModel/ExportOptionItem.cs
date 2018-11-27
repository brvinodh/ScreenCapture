using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ScreenCapture.ViewModel
{
    internal class ExportOptionItem
    {
        public ExportOptionItem(string optionName, ExportOptions optionType)
        {
            this.OptionName = optionName;
            this.OptionType = optionType;
        }

        public string OptionName { get; set; }

        public ExportOptions OptionType { get; set; }
    }

    internal enum ExportOptions
    {
        None, 

        NewWordDocument, 

        OpenDocument
    }
}
