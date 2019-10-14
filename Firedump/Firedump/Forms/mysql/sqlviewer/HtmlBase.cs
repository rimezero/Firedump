using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.Forms.mysql.sqlviewer
{
    class HtmlBase
    {

        public static readonly string HTML_START = "<html><head><title></title><style>textarea {height: auto;}</style></head><body><div contenteditable=\"true\" id=\"sqlcode\" style=\"width:100%;heigth:100%\" >";

        public static readonly string SQL_START = "<textarea style=\"border: none\" id=\"sqlcode\" rows=\"5\" cols=\"100\"  >";
        public static readonly string SQL_END = "</textarea>";

        public static readonly string HTML_END = "</div></body></html>";

    }


}
