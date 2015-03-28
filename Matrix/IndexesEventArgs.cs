﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class IndexChangeEventArgs:EventArgs
    {
        private readonly int i, j;
        public IndexChangeEventArgs(int i, int j)
        {
            this.i = i;
            this.j = j;
        }
        public int IndexI
        {
            get { return i; }
        }

        public int IndexJ
        {
            get { return j; }
        }
    }
}
