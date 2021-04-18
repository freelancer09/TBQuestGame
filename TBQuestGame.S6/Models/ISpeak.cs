using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    interface ISpeak
    {
        List<string> Dialogue { get; set; }

        string RandomDialogue(); 
    }
}
