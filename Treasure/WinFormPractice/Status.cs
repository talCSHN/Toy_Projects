using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormPractice
{
    public class Status
    {
        public Status() { }
        public bool IsMine { get; set; }
        public bool IsOpened {  get; set; }
        public bool IsFlagged {  get; set; }
        public int AdjacentMines {  get; set; }
    }
}
